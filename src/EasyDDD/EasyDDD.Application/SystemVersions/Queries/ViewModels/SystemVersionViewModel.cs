namespace EasyDDD.Application.SystemVersions.Queries.ViewModels
{
    public class SystemVersionViewModel
    {
        public SystemVersionViewModel(string number)
        {
            Number=number;
        }

        public SystemVersionViewModel()
        {
            Number = string.Empty;
        }

        public string Number { get; }

    }
}
