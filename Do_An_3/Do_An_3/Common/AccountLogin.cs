﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_3
{
    [Serializable]
    public class AccountLogin
    {
        public int AccountID { get; set; }
        public string UserName { get; set; }
    }
}