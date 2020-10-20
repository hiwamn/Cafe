using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.Tools.General;

namespace Core.Entities.Functions
{
    public class DtoBuilder
    {

        public static UserLoginDto CreateLoginDto(User user)
        {
            int role = 0;
            if (user.UserRole != null && user.UserRole.Count != 0)
                role = user.UserRole.FirstOrDefault().RoleId;
            return new UserLoginDto
            {
                Id = user.Id,
                Name = user.Name,
                FamilyName = user.FamilyName,
                Mobile = user.Mobile,
                CreatedAt = user.CreatedAt,
                Birthday = user.Birthday,
                Image = user.ProfileImage?.Location,
                Role = role,
                CanReserve = user.CanReserve
            };
        }
        public static UserDto CreateUserDto(User p)
        {
            List<int> role = new List<int> { };
            if (p.UserRole != null && p.UserRole.Count != 0)
                role = p.UserRole.Select(p => p.RoleId).ToList();
            var lastBill = p.Bill?.FirstOrDefault(p => p.StatusId == BillStatus.StaffRelease.ToInt());
            return new UserDto
            {
                Gender = p.Gender,
                Birthday = p.Birthday,
                CreatedAt = p.CreatedAt,
                FamilyName = p.FamilyName,
                Id = p.Id,
                Image = p.ProfileImage?.Location,
                Mobile = p.Mobile,
                Name = p.Name,
                Bio = p.Bio,
                Status = p.Status,
                Balance = p.Transaction?.Where(q => q.IsSuccessful).Sum(q => q.Amount),
                ProfileImageId = p.ProfileImageId,
                Role = role,
                CanReserve = p.CanReserve
                //Bills =  p.TableReserve?.Where(q => q.Bill.Any(t => t.StatusId == BillStatus.Pending.ToInt())).Select(q => DtoBuilder.CreateBillDto(q.Bill.OrderByDescending(t => t.CreatedAt).FirstOrDefault())).ToList(),
            };
        }

        public static string GetTableMessageText(int type, Table tbl)
        {
            string tblName = tbl.Name;

            switch (type)
            {
                case (int)TableMessageType.Filling: return $"میز {tblName} پر شد";
                case (int)TableMessageType.BillCreated: return $"فاکتور میز {tblName} صادر شد";
                case (int)TableMessageType.BillPaid: return $"فاکتور میز {tblName} پرداخت شد";
                case (int)TableMessageType.Decrease: return $"یک نفر از  {tblName} کم شد";
                case (int)TableMessageType.Increase: return $"یک نفر به میز {tblName} اضافه شد";
            }
            return $"تغییری در میز {tblName} اتفاق افتاد";
        }

        public static int MapBillStatusToNotification(int BillS)
        {
            switch (BillS)
            {
                case (int)BillStatus.Pending: return TableMessageType.Filling.ToInt();
                case (int)BillStatus.CardPaid:
                case (int)BillStatus.CashPaid:
                case (int)BillStatus.WalletPaid: return TableMessageType.BillPaid.ToInt();
                case (int)BillStatus.StaffRelease: return TableMessageType.BillCreated.ToInt();
            }
            return 0;
        }

        public static TableMessageDto CreateTableMessageDto(TableMessage p)
        {
            return new TableMessageDto
            {
                Text = p.Text,
                Time = p.CreatedAt,
                Table = CreateTableDto(p.Table),
                Type = p.Type
            };
        }

        public static AdminProductDto CreateAdminProductDto(Product p)
        {
            return new AdminProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price,
                Images = p.ProductImages?.Select(q => new ImageDto { Id = q.Id, Location = q.Document?.Location }).ToList(),
                Children = p.Children?.Select(q => CreateProductDto(q)).ToList(),
                StatusId = p.StatusId,
                StaffPrice = p.StaffPrice
            };
        }

        public static TableReserveDto CreateTableReserveDto(TableReserve p)
        {
            return new TableReserveDto
            {
                Time = p.Time.Value,
                Table = p.Table != null ? CreateTableDto(p.Table) : null,
                User = p.User != null ? CreateShortUserDto(p.User) : null,
                Status = p.StatusId,
                Id = p.Id
            };
        }

        public static MessageDto CreateMessageDto(Message p)
        {
            return new MessageDto
            {
                Id = p.Id,
                Text = p.Text,
                IsFromAdmin = p.IsFromAdmin,
                UserId = p.UserId,
                IsSeen = p.IsSeen
            };
        }

        public static ProductRateDto CreateProductRateDto(ProductRate p)
        {
            return new ProductRateDto
            {
                Id = p.Id,
                Comment = p.Comment,
                StatusId = p.StatusId,
                Rate = p.Rate,
                Product = CreateProductDto(p.Product),
                User = CreateShortUserDto(p.User),
                Children = p.Children?.Select(q => CreateProductRateDto(q)).ToList()
            };
        }

        public static TeamDto CreateTeamDto(Team p, Guid? userId)
        {
            return new TeamDto
            {
                Date = p.Date,
                Id = p.Id,
                MaxCount = p.MaxCount,
                Remained = p.Remained,
                Owner = CreateShortUserDto(p.User),
                Members = p.TeamMember?.Select(q => CreateShortUserDto(q.User)).ToList(),
                IsMine = p.UserId == userId || (p.TeamMember != null && p.TeamMember.Any(q => q.UserId == userId)),
                Price = p.Price,
                Description = p.Description
            };
        }

        public static UserShortDto CreateShortUserDto(User p)
        {
            return new UserShortDto
            {
                Id = p.Id,
                Name = $"{p.Name} {p.FamilyName}",
                Image = p.ProfileImage?.Location,
                Mobile = p.Mobile
            };
        }

        public static TransactionDto CreateTransactionDto(Transaction p)
        {
            return new TransactionDto
            {
                Authority = p.Authority,
                Description = p.Description,
                Id = p.Id,
                IsSuccessful = p.IsSuccessful,
                Price = p.Amount,
                RefId = p.RefId,
                TransactionCategory = CreateTransactionCategoryDto(p.TransactionCategory),
                NextUser = p.NextUser != null ? CreateShortUserDto(p.NextUser) : null,
                CreatedAt = p.CreatedAt,
                Bill = p.Bill != null ? CreateBillDto(p.Bill) : null
            };
        }

        public static OrderDto CreateOrderDto(Bill p)
        {
            return new OrderDto
            {
                CreatedAt = p.CreatedAt,
                Description = p.Description,
                EndedAt = p.EndedAt,
                Id = p.Id,
                StatusId = p.StatusId,
                Table = p.TableReserve != null && p.TableReserve.Table != null ? CreateTableDto(p.TableReserve.Table) : null,
                UpdatedAt = p.UpdatedAt,
                User = CreateUserDto(p.User),
                Items = p.BillItem?.Select(q => CreateBillItemDto(q)).ToList()
            };
        }

        private static TransactionCategoryDto CreateTransactionCategoryDto(TransactionCategory p)
        {
            return new TransactionCategoryDto
            {
                Id = p.Id,
                Name = p.Name
            };
        }

        public static BillDto CreateBillDto(Bill p)
        {
            return new BillDto
            {
                StatusId = p.StatusId,
                PeopleCount = p.PeopleCount,
                Id = p.Id,
                EndedAt = p.EndedAt,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                Table = p.TableReserve != null && p.TableReserve.Table != null ? CreateTableDto(p.TableReserve.Table) : null,
                UpdatedAt = p.UpdatedAt,
                User = p.User != null ? CreateUserDto(p.User) : null,
                Items = p.BillItem?.Select(q => CreateBillItemDto(q)).ToList(),
                Games = p.BillGames?.Select(q => CreateBillGameDto(q)).ToList(),
                Promoter = (p.Promoter != null) ? CreateShortUserDto(p.Promoter) : null,
                Paid = p.Paid
            };
        }

        public static BillGameDto CreateBillGameDto(Bill p)
        {
            return new BillGameDto
            {
                //CreatedAt = p.CreatedAt,
                //Description = p.Description,
                //EndedAt = p.EndedAt,
                //Id = p.Id,
                //StatusId = p.StatusId,
                //Table = p.TableReserve != null && p.TableReserve.Table != null ? CreateTableDto(p.TableReserve.Table) : null,
                //UpdatedAt = p.UpdatedAt,
                //User = CreateUserDto(p.User),
                //Items = p.BillItem?.Select(q => CreateBillItemDto(q)).ToList()
            };
        }

        public static UserLastVisitTimeDto CreateUserLastVisitTimeDto(User p)
        {
            TimeSpan t = new TimeSpan();

            if (p.Bill == null || p.Bill.Count == 0)
                t = Agent.Now.ToDate() - p.CreatedAt.ToDate();
            else
                t = Agent.Now.ToDate() - p.Bill.OrderByDescending(p => p.CreatedAt).FirstOrDefault().CreatedAt.ToDate();
            return new UserLastVisitTimeDto
            {
                User = CreateShortUserDto(p),
                Time = t
            };
        }

        private static BillGameDto CreateBillGameDto(BillGames p)
        {
            return new BillGameDto
            {
                Count = p.Count,
                Description = p.Description,
                From = p.From,
                To = p.To != 0 ? p.To : Agent.Now,
                UnitPriceFirstHour = p.UnitPriceFirstHour,
                UnitPriceOtherHour = p.UnitPriceOtherHour,
                GameType = CreateGameTypeDto(p.GameType)
            };
        }

        public static GetUserDto CreateStaffDto(User p)
        {
            return new GetUserDto
            {
                Gender = p.Gender,
                Birthday = p.Birthday,
                CreatedAt = p.CreatedAt,
                FamilyName = p.FamilyName,
                Id = p.Id,
                Image = p.ProfileImage?.Location,
                Mobile = p.Mobile,
                Name = p.Name,
                Bio = p.Bio,
                Status = p.Status,
                Balance = p.Transaction?.Where(q => q.IsSuccessful).Sum(q => q.Amount),
                Credit = p.Transaction?.Where(q => q.IsSuccessful && (q.TransactionCategoryId == TransactionCategories.DecreaseDailyCredit.ToInt() || q.TransactionCategoryId == TransactionCategories.IncreaseDailyCredit.ToInt())).Sum(q => q.Amount),
                ProfileImageId = p.ProfileImageId,
                Bills = p.Bill?.OrderByDescending(p => p.CreatedAt).Select(q => DtoBuilder.CreateBillDto(q)).ToList()
            };
        }

        public static GetUserDto CreateGetByIdDto(User p)
        {
            List<int> role = new List<int> { };
            if (p.UserRole != null && p.UserRole.Count != 0)
                role = p.UserRole.Select(p => p.RoleId).ToList();
            return new GetUserDto
            {
                Gender = p.Gender,
                Birthday = p.Birthday,
                CreatedAt = p.CreatedAt,
                FamilyName = p.FamilyName,
                Id = p.Id,
                Image = p.ProfileImage?.Location,
                Mobile = p.Mobile,
                Name = p.Name,
                Bio = p.Bio,
                Status = p.Status,
                Balance = p.Transaction?.Where(q => q.IsSuccessful).Sum(q => q.Amount),
                Credit = p.Transaction?.Where(q => q.IsSuccessful && (q.TransactionCategoryId == TransactionCategories.DecreaseDailyCredit.ToInt() || q.TransactionCategoryId == TransactionCategories.IncreaseDailyCredit.ToInt())).Sum(q => q.Amount),
                ProfileImageId = p.ProfileImageId,
                Bills = p.TableReserve?.Where(q => q.Bill.Any(t => t.StatusId == BillStatus.Pending.ToInt() || t.StatusId == BillStatus.StaffRelease.ToInt())).Select(q => DtoBuilder.CreateBillDto(q.Bill.OrderByDescending(t => t.CreatedAt).FirstOrDefault())).ToList(),
                Role = role
            };
        }

        public static TableDto CreateTableDto(Table p)
        {
            var bill = p.TableReserve?.
                Where(p => p.StatusId == TableStatus.Taken.ToInt()).
                FirstOrDefault()?.Bill?.FirstOrDefault();
            if (bill != null && bill.TableReserve != null)
                bill.TableReserve.Table = null;
            return new TableDto
            {
                BarCode = p.BarCode,
                Description = p.Description,
                Id = p.Id,
                Name = p.Name,
                No = p.No,
                MaxCount = p.MaxCount,
                StatusId = p.StatusId,
                IsForGame = p.IsForGame,
                Bill = bill != null ? CreateBillDto(bill) : null,
                Promoter = (bill != null && bill.Promoter!= null)?CreateShortUserDto(bill.Promoter):null
            };

        }

        private static BillItemDto CreateBillItemDto(BillItem p)
        {
            return new BillItemDto
            {

                Count = p.Count,
                CreatedAt = p.CreatedAt,
                Description = p.Description,
                Id = p.Id,
                UnitPrice = p.UnitPrice,
                Product = CreateProductDto(p.Product)
            };
        }

        public static EventAndLeagueDto CreateEventDto(EventAndLeague p)
        {
            return new EventAndLeagueDto
            {
                RemainedCount = p.RemainedCount,
                Description = p.Description,
                GameType = new GameTypeDto { Id = p.GameTypeId, Name = p.GameType.Name },
                Id = p.Id,
                Name = p.Name,
                PaticipantCount = p.TotalCount,
                Price = p.Price,
                DiscountPrice = p.DiscountPrice,
                StartTime = p.StartAt,
                Users = p.EventUsers?.Select(q => CreateUserDto(q.User)).ToList(),
                IsEvent = p.IsEvent,
                CreatedAt = p.CreatedAt
            };
        }

        public static GroupGameDto CreateGroupGameDto(GroupGame p)
        {
            return new GroupGameDto
            {
                RemainedCount = p.RemainedCount,
                Description = p.Description,
                GameType = new GameTypeDto { Id = p.GameTypeId, Name = p.GameType.Name },
                Id = p.Id,
                Name = p.Name,
                DiscountPrice = p.DiscountPrice,
                TotalCount = p.TotalCount,
                Price = p.Price,
                StartTime = p.StartAt,
                Users = p.GroupGameUsers.Select(q => CreateUserDto(q.User)).ToList()

            };
        }

        public static ProductDto CreateProductDto(Product p)
        {
            if (p != null)
                return new ProductDto
                {
                    Id = p.Id,
                    Description = p.Description,
                    Name = p.Name,
                    Price = p.Price,
                    Parent = p.Parent != null ? CreateFixedGuid(p.Parent) : null,
                    Images = p.ProductImages?.Select(q => q.Document?.Location).ToList(),
                    Children = p.Children?.Select(q => CreateProductDto(q)).ToList(),
                    StatusId = p.StatusId,
                    StaffPrice = p.StaffPrice
                };
            return null;
        }

        private static FixedGuidDto CreateFixedGuid(Product p)
        {
            return new FixedGuidDto
            {
                Id = p.Id,
                Name = p.Name
            };
        }

        public static BarginCampaignDto CreateBarginCampaignDto(BarginCampaign p)
        {
            return new BarginCampaignDto
            {
                RemainedCount = p.RemainedCount,
                BarginType = CreateBarginTypeDto(p.BarginType),
                Description = p.Description,
                GameType = CreateGameTypeDto(p.GameType),
                Id = p.Id,
                ParticipantCount = p.TotalCount,
                StartTime = p.StartTime,
                Value = p.Value,
                Users = p.BarginUsers?.Select(q => CreateUserDto(q.User)).ToList(),
                IsProductDiscount = p.IsProductDiscount
            };
        }



        public static GameTypeDto CreateGameTypeDto(GameType p)
        {
            return new GameTypeDto
            {
                Id = p.Id,
                Name = p.Name,
                UnitPriceFirstHour = p.PricePerFirstHour,
                UnitPriceOtherHour = p.PricePerOtherhour,
                HourCount = 4
            };
        }

        private static BarginTypeDto CreateBarginTypeDto(BarginType p)
        {
            return new BarginTypeDto
            {
                Id = p.Id,
                Name = p.Name
            };
        }
    }
}
