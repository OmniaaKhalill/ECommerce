namespace E_Commerce.APIs.DTO
{
    public class UploadFileResult
    {

       
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public string Url { get; set; }
            public UploadFileResult(bool IsSuccess, string Message, string Url)
            {

                this.IsSuccess = IsSuccess;
                this.Message = Message;
                this.Url = Url;

            }



        }

    }

