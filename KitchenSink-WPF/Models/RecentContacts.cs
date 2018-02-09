﻿#region License
// Copyright (c) 2016-2017 Cisco Systems, Inc.

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenSink
{
    public class RecentContacts
    {
        private string user;
        private string strCurUserDir;
        public string FileName
        {
            get
            {
                return strCurUserDir + user + "_RecentContacts.txt";
            }
        }
        
        private List<string> recentContactsStore;
        public List<string> RecentContactsStore
        {
            get
            {
                return this.recentContactsStore;
            }
        }

        public RecentContacts()
        {
            strCurUserDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            strCurUserDir += "\\" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + "\\";

            user = ApplicationController.Instance.CurSparkManager?.CurUser?.DisplayName;
            this.recentContactsStore = TextListConverter.ReadTextFileToList(FileName);
        }

        public void AddRecentContactsStore(string personId)
        {
            if (!RecentContactsStore.Exists(item => item == personId))
            {
                RecentContactsStore.Add(personId);
                TextListConverter.WriteListToTextFile(this.RecentContactsStore, FileName);
            }
            
        }
    }
}
