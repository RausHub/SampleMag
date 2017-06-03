var app = angular.module('SampleMag', ['ngRoute', 'firebase', 'videosharing-embed','angucomplete-alt']);

//Firebase URL
app.constant('fbURL', 'https://samplemag-2696a.firebaseio.com');

//Factory for Firebase
app.factory('Posts', function ($firebase, fbURL) {
    return $firebase(new Firebase(fbURL)).$asArray();
});

//RouteProviders
app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
        templateUrl: 'home.html',
        controller: 'SmagController'

    })
    .when('/login', {
        templateUrl: 'login.html',
        controller: 'SmagController'

    })
    .when('/create', {
        templateUrl: 'create.html',
        controller: 'SmagController'
    })
     .when('/register', {
        templateUrl: 'register.html',
        controller: 'SmagController'
    })
    .when('/profile', {
        templateUrl: 'profile.html',
        controller: 'SmagController'
    })
    .otherwise({
        redirectTo: '/'
    })
});

//CreateController
app.controller('SmagController', function ($scope, $firebase, Posts) {

    //post to global variable
    $scope.posts = Posts;
    $scope.votes = [];
    
     //save post function
    $scope.savePost = function (post) {
        if (post.title && post.content) {
            //Adding the posts
            Posts.$add({
                
                title: post.title,
                artist: post.artist,
                category: post.category,
                content: post.content,
                location: post.location,
                url: post.url,
                //Votes
                votes: 0
                
            });

            //Resetting the values
            post.title = "";
            post.artist = "";
            post.category = "";
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


    
    
    
  


    


  