namespace ApiTest.DataModule.Tests
{
    [TestClass]
    public class DataModuleTests
    {
        // GetExternalUrl
        [TestMethod]
        public void GetExternalUrl_ShouldReturnFullTypeWithIndex()
        {
            string urlString = DataModuleService.GetExternalUrl("ApiTest.DataModule.Post", 3);

            Assert.AreEqual(urlString, "https://jsonplaceholder.typicode.com/posts/3");
        }

        [TestMethod]
        public void GetExternalUrl_ShouldReturnFullTypeWithoutIndex()
        {
            string urlString = DataModuleService.GetExternalUrl("ApiTest.DataModule.Album");

            Assert.AreEqual(urlString, "https://jsonplaceholder.typicode.com/albums");
        }

        //FetchDataAsync - lists
        [TestMethod]
        public async Task FetchDataAsync_ShouldReturnCorrectTypeUser()
        {
            var result = await DataModuleService.FetchDataAsync<User>();
            Assert.IsInstanceOfType(result, typeof(List<User>));
        }

        [TestMethod]
        public async Task FetchDataAsync_ShouldReturnCorrectTypeAlbum()
        {
            var result = await DataModuleService.FetchDataAsync<Album>();
            Assert.IsInstanceOfType(result, typeof(List<Album>));
        }

        [TestMethod]
        public async Task FetchDataAsync_ShouldReturnCorrectTypePost()
        {
            var result = await DataModuleService.FetchDataAsync<Post>();
            Assert.IsInstanceOfType(result, typeof(List<Post>));
        }

        //FetchDataAsync - individual
        [TestMethod]
        public async Task FetchDataAsync_ShouldReturnListOfCorrectTypeUser()
        {
            var result = await DataModuleService.FetchDataAsync<User>(1);
            Assert.IsInstanceOfType(result, typeof(List<User>));
            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public async Task FetchDataAsync_ShouldReturnListOfCorrectTypeAlbum()
        {
            var result = await DataModuleService.FetchDataAsync<Album>(1);
            Assert.IsInstanceOfType(result, typeof(List<Album>));
            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public async Task FetchDataAsync_ShouldReturnListOfCorrectTypePost()
        {
            var result = await DataModuleService.FetchDataAsync<Post>(1);
            Assert.IsInstanceOfType(result, typeof(List<Post>));
            Assert.IsTrue(result.Count == 1);
        }

        //PostDataAsync
        [TestMethod]
        public async Task PostDataAsync_ShouldReturnUser()
        {
            var result = await DataModuleService.PostDataAsync<User>(new User());
            Assert.IsInstanceOfType(result, typeof(User));
        }

        public async Task PostDataAsync_ShouldReturnAlbum()
        {
            var result = await DataModuleService.PostDataAsync<Album>(new Album());
            Assert.IsInstanceOfType(result, typeof(Album));
        }

        public async Task PostDataAsync_ShouldReturnPost()
        {
            var result = await DataModuleService.PostDataAsync<Post>(new Post());
            Assert.IsInstanceOfType(result, typeof(Post));
        }

        //PutDataAsync
        [TestMethod]
        public async Task PutDataAsync_ShouldReturnUser()
        {
            var result = await DataModuleService.PutDataAsync<User>(new User(), 1);
            Assert.IsInstanceOfType(result, typeof(User));
        }

        public async Task PutDataAsync_ShouldReturnAlbum()
        {
            var result = await DataModuleService.PutDataAsync<Album>(new Album(), 1);
            Assert.IsInstanceOfType(result, typeof(Album));
        }

        public async Task PutDataAsync_ShouldReturnPost()
        {
            var result = await DataModuleService.PutDataAsync<Post>(new Post(), 1);
            Assert.IsInstanceOfType(result, typeof(Post));
        }

        //DeleteDataAsync
        [TestMethod]
        public async Task DeleteDataAsync_ShouldReturnUser()
        {
            var result = await DataModuleService.DeleteDataAsync<User>(1);
            Assert.IsTrue(result == true);
        }

        public async Task DeleteDataAsync_ShouldReturnAlbum()
        {
            var result = await DataModuleService.DeleteDataAsync<Album>(1);
            Assert.IsTrue(result == true);
        }

        public async Task DeleteDataAsync_ShouldReturnPost()
        {
            var result = await DataModuleService.DeleteDataAsync<Post>(1);
            Assert.IsTrue(result == true);
        }

        //GetCollectionAsync
        [TestMethod]
        public async Task GetCollectionAsync_ShouldReturnExactCount()
        {
            var result = await DataModuleService.GetCollectionAsync();
            Assert.IsInstanceOfType(result, typeof(List<Collection>));
            Assert.IsTrue(result.Count == 30);
        }
    }
}