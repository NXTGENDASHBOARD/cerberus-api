using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cerberus.Dashboard.Application.ViewModels.Email
{
    public class EmailMessageViewModel
    {
        public List<string> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        [JsonConstructor]
        public EmailMessageViewModel() { }
        public EmailMessageViewModel(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {
            To = new List<string>();

            To.AddRange(to);
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
