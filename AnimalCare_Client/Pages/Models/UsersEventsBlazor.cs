 using AnimalCare_Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimalCare_Client.Pages.Models
{
    public class UsersEventsBlazor : ComponentBase, IDisposable
    {

        #region Properties
        
        protected bool isSelected = true;
       
        protected EventModel eventModel { get; set; }
        
        protected List<UserModel> listUsers { get; set; }
        protected UserModel User { get ; set ; }
        
        [Inject]
        protected NavigationManager navigation{ get; set; }

        #endregion

        #region Parameters
          
        [Parameter]
        public int IdUser { get; set; }
        [Parameter]
        public int IdEvent { get; set; }

        #endregion

        protected async Task<UserModel> GetUserEventsAsync(int idUser)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44369/api/User/Specialiste/" + idUser))
                {
                    var responseAPI = await response.Content.ReadAsStringAsync();
                    if ( response.StatusCode == HttpStatusCode.OK)
                    {
                          User =   JsonConvert.DeserializeObject<UserModel>(responseAPI);
 
                    }
                    if (idUser > 0)
                    {
                        if(!(response.StatusCode == HttpStatusCode.OK))
                        {
                            navigation.NavigateTo("/");
                        }
                    }

                    return User;



                }

            }
        }
        protected async Task<List<UserModel>> GetUsersEventsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44369/api/User/UsersEvents"))
                {
                    var responseAPI = await response.Content.ReadAsStringAsync();

                   return listUsers = JsonConvert.DeserializeObject<List<UserModel>>(responseAPI);

                }


            }
        }
 
        protected async Task<EventModel> GetEventByUser(int idEvent)
        {
        

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44369/api/Event/" + idEvent))
                {
                    var responseAPI = await response.Content.ReadAsStringAsync();
                     
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        eventModel = JsonConvert.DeserializeObject<EventModel>(responseAPI);

                    }
                    if (idEvent > 0)
                    {
                        if (!(response.StatusCode == HttpStatusCode.OK))
                        {
                            navigation.NavigateTo("/");
                        }
                    }

                }
            }

            return eventModel;



        }
        protected void FonctionalitiesUsersEvents(List<UserModel> listUsersModel)
        {
            foreach (var user in listUsersModel)
            {
                user.Calendar.DictionaryMonth = user.Calendar.GetDictionaryMonth();
                user.Calendar.currentMonth = DateTime.Now.Month;
                user.Calendar.currentYear = DateTime.Now.Year;
                user.Calendar.DaysInMonth = user.Calendar.GetNumberDaysInMonth(user.Calendar.currentYear, user.Calendar.currentMonth);
                //_user.Calendar.IdCalendar = user.IdUser;
                // nombre de semaine par mois
                //user.Calendar.intervalLastDayAndFirstDay(user.Calendar.currentYear, user.Calendar.currentMonth);

                //date pour afficher les jour du mois (lun,mar,mer...)
                //user.Calendar.date = new DateTime(user.Calendar.currentYear, user.Calendar.currentMonth, 1);
            }
        }
        protected void FonctionalitiesUserEvents(UserModel userModel)
        {

            userModel.Calendar.DictionaryMonth = userModel.Calendar.GetDictionaryMonth();
            userModel.Calendar.currentMonth = DateTime.Now.Month;
            userModel.Calendar.currentYear = DateTime.Now.Year;
            userModel.Calendar.DaysInMonth = userModel.Calendar.GetNumberDaysInMonth(userModel.Calendar.currentYear, userModel.Calendar.currentMonth);


        }


        #region composant d'initialisation Async
        protected override async Task OnInitializedAsync()
        {
           
            //list users with events
            listUsers = await GetUsersEventsAsync();
                FonctionalitiesUsersEvents(listUsers);

            // get user with Events
           
                User = await GetUserEventsAsync(IdUser);
                FonctionalitiesUserEvents(User);
          
           

            // get Event
            eventModel = await GetEventByUser(IdEvent);

           
            base.OnInitialized();
        }

        #endregion
     

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
      

        #region composant d'initialisationq
        protected override void OnInitialized()
        {   //test form
            eventModel = new EventModel();
            listUsers = new List<UserModel>();
            User = new UserModel();
           
            base.OnInitialized();
        }
      
        #endregion

        public void naviToEvent()
        {
            navigation.NavigateTo("/");
        }
        
        
          
        //public async Task handleChangeAsync()
        //{
        //    //test form

        //    UserModel userModel = new UserModel();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44369/Specialiste/" + userModel.IdUser))
        //        {
        //            var responseAPI = await response.Content.ReadAsStringAsync();

        //            userModel = JsonConvert.DeserializeObject<UserModel>(responseAPI);
        //        }

        //    }
              
               

        //    var user = new UserModel();
        //    _ = Task.Delay(0).ContinueWith(_ => { user = userModel; InvokeAsync(StateHasChanged); });
        //    Console.WriteLine("refreshList sucess ");

        //}
       
       
        public async Task SendEvent(EventModel eventModel)
        {
            using (var client = new HttpClient())
            {
                var SendEvent = new EventModel() { Status = eventModel.Status, DateEvent = eventModel.DateEvent };
                string stringData = JsonConvert.SerializeObject(SendEvent);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/Json");
                var response = await client.PostAsync("https://localhost:44369/api/Event/", contentData);
                var result =    response.IsSuccessStatusCode;
                Console.WriteLine("httpPost Created ");
                //if (result)
                //{
                //    var resfreshUser = handleChangeAsync();

                //}
            }
        }



    
        public void Confirme()
        {
            isSelected = false;

        }
        public void Annule()
        {
            isSelected = true;

        }
        public void Dispose()
        {
            Console.WriteLine("dispose");
        }

        public void Reservation()
        {

            //var updateEvent = crudEventServices.Update(id,Ev);
        }


    }
}
