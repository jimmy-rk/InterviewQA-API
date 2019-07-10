using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewQAApi.Models
{
    public class InterviewQA
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Language { get; set; }
        public string Topic { get; set; }
    }
}
