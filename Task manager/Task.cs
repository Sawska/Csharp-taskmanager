using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task_manager
{
    public class Task
    {
        
        public string name { get; set; }
        
        public string DeadLine { get; set; }
        
        public bool complited { get; set; }

        public Task(string name, string DeadLine = "")
        {
            this.name = name;
            this.DeadLine = DeadLine;
            complited = false;
        }

    }

}

