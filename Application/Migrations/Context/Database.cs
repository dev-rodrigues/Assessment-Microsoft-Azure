﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Database {
    public class Database {
        public static DatabaseContext GetInstance = new DatabaseContext();
    }
}
