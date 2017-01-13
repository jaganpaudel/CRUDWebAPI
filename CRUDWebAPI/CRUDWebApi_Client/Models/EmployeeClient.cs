using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Web.Mvc;
using System.Net.Http.Headers;

namespace CRUDWebApi_Client.Models
{
    public class EmployeeClient
    {
        public string BASE_URL = "http://localhost:54551/";

        public IEnumerable<Employee> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Employee").Result;
               // string me = response.RequestMessage.ToString();
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;

                }
                else
                {
                    return null;
                }

            }
            catch(Exception e)
            {
                throw;
            }
        }

        public Employee find(int ID)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Employee/" + ID).Result;
                string me = response.RequestMessage.ToString();
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Employee>().Result;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Create(Employee employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/Employee",employee).Result;
                return response.IsSuccessStatusCode;
               

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Edit(Employee employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("api/Employee/" + Convert.ToInt16(employee.Employee_ID), employee).Result;
                return response.IsSuccessStatusCode;


            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Delete(decimal id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("api/Employee/" + id).Result;
                return response.IsSuccessStatusCode;


            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}