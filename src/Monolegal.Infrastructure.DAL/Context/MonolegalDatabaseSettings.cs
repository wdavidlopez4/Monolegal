﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Monolegal.Infrastructure.DAL.Context
{
    public class MonolegalDatabaseSettings:IMonolegalDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
