var app = angular.module('SampleMag', ['ngRoute', 'firebase', 'videosharing-embed']);

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
        controller: 'LogController'

    })
    .when('/create', {
        templateUrl: 'create.html',
        controller: 'CreateController'
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

app.controller('LogController', function ($scope, $firebase, Posts) {

    //post to global variable
    $scope.votes = [];
    
});

app.controller('CreateController', function ($scope, $firebase, Posts) {

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

  
});


angular.module("videosharing-embed",[]),angular.module("videosharing-embed").service("PlayerConfig",function(){"use strict";this.createInstance=function(a){var b=function(a){this.type=a.type,this.playerRegExp=a.playerRegExp,this.timeRegExp=a.timeRegExp,this.whitelist=a.whitelist,this.playerID=a.playerID,this.settings=a.settings,this.transformAttrMap=a.transformAttrMap,this.processSettings=a.processSettings,this.isPlayerFromURL=function(a){return null!=a.match(this.playerRegExp)},this.buildSrcURL=a.buildSrcURL,this.isAdditionaResRequired=a.isAdditionaResRequired,this.additionalRes=a.additionalRes};return new b(a)}}),angular.module("videosharing-embed").factory("RegisteredPlayers",["PlayerConfig","$filter","$window",function(a,b,c){"use strict";var d={youtube:{type:"youtube",settings:{autoplay:0,controls:1,loop:0},whitelist:["autohide","cc_load_policy","color","disablekb","enablejsapi","autoplay","controls","loop","playlist","rel","wmode","start","showinfo","end","fs","hl","iv_load_policy","list","listType","modestbranding","origin","playerapiid","playsinline","theme"],transformAttrMap:{},processSettings:function(a,b){return 1==a.loop&&void 0==a.playlist&&(a.playlist=b),a},buildSrcURL:function(a,c){return a+this.playerID+c+b("videoSettings")(this.processSettings(this.settings))},playerID:"www.youtube.com/embed/",playerRegExp:/([a-z\:\/]*\/\/)(?:www\.)?(?:youtube(?:-nocookie)?\.com\/(?:[^\/\n\s]+\/\S+\/|(?:v|e(?:mbed)?)\/|\S*?[?&]v=)|youtu\.be\/)([a-zA-Z0-9_-]{11})/,timeRegExp:/t=(([0-9]+)h)?(([0-9]{1,2})m)?(([0-9]+)s?)?/,isAdditionaResRequired:function(){return!1},additionalRes:[]},vimeo:{type:"vimeo",settings:{autoplay:0,loop:0,api:0,player_id:""},whitelist:["autoplay","autopause","badge","byline","color","portrait","loop","api","playerId","title"],transformAttrMap:{playerId:"player_id"},processSettings:function(a,b){return a},buildSrcURL:function(a,c){return a+this.playerID+c+b("videoSettings")(this.processSettings(this.settings))},playerID:"player.vimeo.com/video/",playerRegExp:/([a-z\:\/]*\/\/)(?:www\.)?vimeo\.com\/(?:channels\/[A-Za-z0-9]+\/)?([A-Za-z0-9]+)/,timeRegExp:"",isAdditionaResRequired:function(){return!1},additionalRes:[]},dailymotion:{type:"dailymotion",settings:{autoPlay:0,logo:0},whitelist:["api","autoplay","background","chromeless","controls","foreground","highlight","html","id","info","logo","network","quality","related","startscreen","webkit-playsinline","syndication"],transformAttrMap:{},processSettings:function(a,b){return a},buildSrcURL:function(a,c){return a+this.playerID+c+b("videoSettings")(this.processSettings(this.settings))},playerID:"www.dailymotion.com/embed/video/",playerRegExp:/([a-z\:\/]*\/\/)(?:www\.)?www\.dailymotion\.com\/video\/([A-Za-z0-9]+)/,timeRegExp:/start=([0-9]+)/,isAdditionaResRequired:function(){return!1},additionalRes:[]},youku:{type:"youku",settings:{},whitelist:[],transformAttrMap:{},processSettings:function(a,b){return a},buildSrcURL:function(a,c){return a+this.playerID+c+b("videoSettings")(this.processSettings(this.settings))},playerID:"player.youku.com/embed/",playerRegExp:/([a-z\:\/]*\/\/)(?:www\.)?youku\.com\/v_show\/id_([A-Za-z0-9]+).html/,timeRegExp:"",isAdditionaResRequired:function(){return!1},additionalRes:[]},vine:{type:"vine",settings:{audio:0,start:0,type:"simple"},whitelist:["audio","start","type"],transformAttrMap:{},processSettings:function(a,b){return a},buildSrcURL:function(a,c){var d=this.settings.type;return a+this.playerID+c+/embed/+d+b("videoSettings")(this.processSettings(this.settings))},playerID:"vine.co/v/",playerRegExp:/([a-z\:\/]*\/\/)(?:www\.)?vine\.co\/v\/([A-Za-z0-9]+)/,timeRegExp:"",isAdditionaResRequired:function(){return!c.VINE_EMBEDS},additionalRes:[{id:"ng-video-embed-vine-res-1",element:'<script id="ng-video-embed-vine-res-1" src="//platform.vine.co/static/scripts/embed.js"></script>'}]}},e=[];return angular.forEach(d,function(b){e.push(a.createInstance(b))}),e}]),angular.module("videosharing-embed").filter("whitelist",function(){"use strict";return function(a,b){var c={};return angular.forEach(a,function(a,d){b.indexOf(d)!=-1&&(c[d]=a)}),c}}),angular.module("videosharing-embed").filter("videoSettings",function(){"use strict";return function(a){var b=[];return angular.forEach(a,function(a,c){b.push([c,a].join("="))}),b.length>0?"?"+b.join("&"):""}}),angular.module("videosharing-embed").directive("embedVideo",["$filter","RegisteredPlayers","$sce","$window",function(a,b,c,d){"use strict";return{restrict:"E",template:'<iframe width="{{width}}" height="{{height}}" data-ng-src="{{trustedVideoSrc}}" frameborder="0"></iframe>',scope:{allowfullscreen:"@",height:"@",width:"@",onChange:"&"},link:function(e,f,g){var h=f.find("iframe"),i=void 0,j=angular.isString(g.forceProtocol)?g.forceProtocol+"://":void 0;e.allowfullscreen=void 0===e.allowfullscreen||"true"===e.allowfullscreen,e.allowfullscreen?h.attr("allowfullscreen",""):h.removeAttr("allowfullscreen"),g.$observe("width",function(a){e.width=a}),g.$observe("height",function(a){e.height=a}),g.$observe("iframeId",function(a){return a?void h.attr("id",a):void h.removeAttr("id")}),g.$observe("href",function(f){if(void 0!==f&&f!==i){i=f;var h=null;if(angular.forEach(b,function(a){a.isPlayerFromURL(f)&&(h=a)}),null===h)return void e.onChange();var k=f.match(h.playerRegExp);j=j||k[1];var l=k[2],m=f.match(h.timeRegExp);h.config;if(angular.forEach(a("whitelist")(g,h.whitelist),function(a,b){var c=void 0!=h.transformAttrMap[b]?h.transformAttrMap[b]:b;h.settings[c]=a}),h.settings.start=0,m)switch(h.type){case"youtube":h.settings.start+=60*parseInt(m[2]||"0")*60,h.settings.start+=60*parseInt(m[4]||"0"),h.settings.start+=parseInt(m[6]||"0");break;case"dailymotion":h.settings.start+=parseInt(m[1]||"0")}if(h.isAdditionaResRequired())for(var n=angular.element(d.document.querySelector("body")),o=0;o<h.additionalRes.length;o++){var p=h.additionalRes[o];null==d.document.querySelector("#"+p.id)&&n.append(p.element)}e.onChange({videoId:l,provider:h.type});var q=h.buildSrcURL(j,l);e.trustedVideoSrc=c.trustAsResourceUrl(q)}})}}}]);