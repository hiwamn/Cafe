using Core.Contracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        private readonly IContext ctx;

        public DocumentRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

    }
}
