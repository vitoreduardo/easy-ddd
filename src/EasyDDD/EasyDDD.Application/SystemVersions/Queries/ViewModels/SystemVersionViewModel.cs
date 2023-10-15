namespace EasyDDD.Application.SystemVersions.Queries.ViewModels
{
    public class SystemVersionViewModel
    {
        public SystemVersionViewModel(string number)
        {
            Number=number;
        }

        public string Number { get; }

    }
}
