using ChatFun.Core;
using ChatFun.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFun.MVVM.ViewModel
{
	class MainViewModel : ObservableObject
	{
		public ObservableCollection<MessageModel> Messages { get; set; }
		public ObservableCollection<ContactModel> Contacts { get; set; }

		public ContactModel SelectedContact { get; set; }

		private string _message;

		public string Message
		{
			get { return _message; }
			set { 
				   _message = value;
				   OnPropertyChanged();
			}
		}

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            Messages.Add(new MessageModel
            {
                Username = "Abhi",
                UsernameColor = "#409af",
                ImageSource = "https://www.pexels.com/photo/man-doing-a-sample-test-in-the-laboratory-4033148/",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for(int i = 0; i < 3; i++)
             {
				Messages.Add(new MessageModel
				{
					Username = "Abhi",
					UsernameColor = "#409af",
					ImageSource = "https://www.pexels.com/photo/man-doing-a-sample-test-in-the-laboratory-4033148/",
					Message = "Test",
					Time = DateTime.Now,
					IsNativeOrigin = false,
					FirstMessage =false
				});
			}

			for (int i = 0; i < 3; i++)
			{
				Messages.Add(new MessageModel
				{
					Username = "Vivek",
					UsernameColor = "#409af",
					ImageSource = "https://www.pexels.com/photo/sommelier-pouring-wine-in-winery-5490193/",
					Message = "Test",
					Time = DateTime.Now,
					IsNativeOrigin = true
				});
			}

			Messages.Add(new MessageModel
			{
				Username = "Vivek",
				UsernameColor = "#409af",
				ImageSource = "https://www.pexels.com/photo/sommelier-pouring-wine-in-winery-5490193/",
				Message = "Last",
				Time = DateTime.Now,
				IsNativeOrigin = true
			});

			for(int i = 0; i < 5; i++)
			{
				Contacts.Add(new ContactModel
				{
					Username = $"Abhi{i}",
					ImageSource = "https://www.pexels.com/photo/man-doing-a-sample-test-in-the-laboratory-4033148/",
					Messages = Messages
				});
			}
		}


    }
}
