using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// AANA
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using CoreDemoADO.NET;
using CoreDemoEF.Application;
using System.Net.Http;

namespace CoreDemoADO.NET.Tests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        // Constructor
        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }



        [Theory]
        //[InlineData("/")]
        //[InlineData("/Home")]
        //[InlineData("/Home/Index")]
        //[InlineData("/Home/Privacy")]

        [InlineData("/Employees/ListEmployees")]


        public async Task GetHttpRequest(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());


            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("zBoski", responseString);

        }



        [Fact]
        public async Task Create_StaffMember_ReturnsNoErrors()
        {

            var client = _factory.CreateClient();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Employees/Create");

            string firstName = "Josephine";
            string lastName = "Kaurs";

            var formModel = new Dictionary<string, string>
            {
                { "Title", "Miss" },
                { "FirstName", firstName },
                { "LastName", lastName }
            };


            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Ensure responseString contains firstName
            Assert.Contains(firstName, responseString);

            // Ensure responseString contains firstName
            Assert.Contains(lastName +"z", responseString);

        }



        [Fact]
        public async Task Create_StaffMember_ReturnsErrorFirstNameMin5Chars()
        {

            var client = _factory.CreateClient();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Employees/Create");

            string firstName = "Caro";
            string lastName = "Smiths";

            var formModel = new Dictionary<string, string>
            {
                { "Title", "Miss" },
                { "FirstName", firstName },
                { "LastName", lastName }
            };


            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Ensure responseString contains "minimum length of 5"
            Assert.Contains("minimum length of 5", responseString);

        }



        [Fact]
        public async Task Update_StaffMember_ReturnsNoErrors()
        {

            var client = _factory.CreateClient();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Employees/Edit");

            string firstName = "Harry";
            string lastName = "Smith";

            var formModel = new Dictionary<string, string>
            {

                { "Id", "14" },
                { "Title", "Mr" },
                { "FirstName", firstName },
                { "LastName", lastName }
            };


            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Ensure responseString contains firstName
            Assert.Contains(firstName, responseString);

            // Ensure responseString contains firstName
            Assert.Contains(lastName, responseString);

        }



        [Fact]
        public async Task Delete_StaffMember_ReturnsNoErrors()
        {

            var client = _factory.CreateClient();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Employees/Delete");


            var formModel = new Dictionary<string, string>
            {

                { "Id", "11" },
            };

            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Ensure responseString contains firstName
            //Assert.DoesNotContain(firstName, responseString);

            // Ensure responseString does not contain firstName
            //Assert.DoesNotContain(lastName, responseString);

        }



        [Fact]
        public async Task Delete_StaffMember_ReturnsErrors()
        {

            var client = _factory.CreateClient();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Employees/Delete");


            var formModel = new Dictionary<string, string>
            {

                { "Id", "191" },
            };

            postRequest.Content = new FormUrlEncodedContent(formModel);

            var response = await client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();

        }

    }
}
