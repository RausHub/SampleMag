var app = angular.module('SampleMag', ['ngRoute']);

console.log("test");

//app.factory('GetSamples', function ($http) {
//    $http({
//        method: "GET",
//        url: "sample/samples"
//    }).then(function (result) {
//        $scope.samplelist = result.data;
//    });
//});

//RouteProviders
app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'SmagController',
            templateUrl: 'scripts/spa/sample/listSamples.html'
        })
        .when('/create', {
            controller: 'SmagController',
            templateUrl: 'scripts/spa/sample/Create.html'
        })
        //.when('/login', {
        //    controller: 'SmagController',
        //    templateUrl: './Login/templates/login.html'
        //})
        //.when('/register', {
        //    controller: 'SmagController',
        //    templateUrl: './Login/templates/register.html'
        //})
        .otherwise({
            redirectTo: '/'
        });
});

//CreateController
app.controller('SmagController', function ($scope, $firebase, Posts) {

    //post to global variable
    $scope.posts = Posts;

    //save post function
    $scope.savePost = function (post) {
        if (post.title && post.content) {
            //Adding the posts
            Posts.$add({
                
                title: post.title,
                artist: post.artist,
                content: post.content,
                location: post.location,
                url: post.url,
                //Votes
                votes: 0
                
            });

            //Resetting the values
            post.title = "";
            post.artist = "";
            post.content = "";
            post.location = "";
            post.url = "";
        } else {
            //An alert to tell the user (to log in) or put something in some of the fields
            alert('You need at least a title and content to be filled or you need to be logged in!')
        }
    }

    //Adding a vote
    $scope.addVote = function (post) {
        //Increment the number
        post.votes++;
        //Save to the Firebase
        Posts.$save(post);
    }

    //Deleting a post
    $scope.deletePost = function (post) {
        //Getting the right URL
        var postForDeletion = new Firebase('https://samplemag-2696a.firebaseio.com/' + post.$id);
        //Removing it from Firebase
        postForDeletion.remove();
    }

});