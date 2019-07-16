using System;
using System.Collections.Generic;

namespace CA_RestAPIRequest
{
    public class CreateUpdateUserResponse
    {
        public Guid UploadId { get; set; }
        public DateTime ProcessDate { get; set; }
        public bool HasErrors { get; set; }
        public List<ErrorsDescriptions> ErrorsDescription { get; set; }
        public int LoadedItems { get; set; }
        public int ProcessedItems { get; set; }
        public int ErrorItems { get; set; }
    }

    public class ErrorsDescriptions
    {
        public int Line { get; set; }
        public string ErrorDescription { get; set; }
    }
}
