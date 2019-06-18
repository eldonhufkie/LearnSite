//var video_List = ["https://www.youtube.com/embed/cpPG0bKHYKc", "https://www.youtube.com/embed/dX2-V2BocqQ", "https://www.youtube.com/embed/bfEDcghjceg"];

//$(document).ready(function () {
//    //Get the list of videos
//    //For now just create a default list
//    LoadVideos();
//    $("#video").attr("src", FirstVideo);

//    //$("btnNext1").click(function () {
//    //    let option = {};
//    //    option.url = "/Video/GetVideoByID/";
//    //    option.type = "GET";
//    //    option.dataType = "JSON";
//    //    option.success = function (data) {
//    //        //$("#video").attr("src",option.);
//    //        document.getElementById("Videoname").innerHTML = data.VideoUrl + "Download and Install Python";
//    //    };
//    //    $.ajax(options);
//    //});
//});


////function playNext(index) {
////    // alert("testing");
////    $("#video").attr("src", video_List[index]);
////    document.getElementById("Videoname").innerHTML = "Download and Install Python";
////    document.getElementById("briefDescription").innerHTML = "<ul>To download python, visit the " + '<a href="https://www.python.org/downloads/">Python Website</a></ul>'
////}

////
//function NextVideo(id) {
//    $.ajax({
//        url: '/Video/GetVideoByID/',
//        type: 'POST',
//        dataType: 'JSON',
//        params: {
//            id: id
//        },
//        success: function (data) {
//            $("#video").attr("src", "https://youtube.com/embed/" + data.videoUrl);


//        }
//    })
//}
//function FirstVideo() {
//    $.ajax({
//        url: '/Video/GetFirstVideo/',
//        type: 'POST',
//        dataType: 'JSON',
//        success: function (data) {
//            $("#video").attr("src", "https://youtube.com/embed/" + data.videoUrl);


//        }
//    })
//}
////function TheNextVideo() {
////    $.ajax({
////        url: '/Video/GetSection/',
////        type: 'POST',
////        dataType: 'JSON',
////        success: function (data) {
////            $("#video").attr("src", "https://youtube.com/embed/" + data[0].videos[2].videoUrl);
////            var len = data[0].videos.length;

////        }
////    })
////}

//function LoadVideos() {
//    $.ajax({
//        url: '/Video/GetSection/',
//        type: 'POST',
//        dataType: 'JSON',
//        success: function (data) {
//            //$("#video").attr("src", "https://youtube.com/embed/" + data[0].videos[2].videoUrl);
//            //document.getElementById("Videoname").innerHTML = data[0].videos[2].videoName;
//            //var len = data.length;
//            // document.getElementById('divID').innerHTML = '';
//            var section = '';
//            var VideosHeading = '';
//            //loop to add accordian
//            for (var i = 0; i < data.length; i++) {
//                //sections
//                section += '<p>' +
//                    '<a class="btn btn-block" data-toggle="collapse" href="#collapse' + i + '" role="button" aria-expanded="false" aria-controls="collapse' + i + '">' +
//                    'Section ' + (i + 1) + ': ' + data[i].sectionName +
//                    '</a>' +
//                    '</p>' +
//                    '<div class="collapse" id="collapse' + i + '">'
//                for (var j = 0; j < data[i].videos.length; j++) {
//                    //var video_Name = data[i].vid
//                    //var url = data[i].videos[j].videoUrl;//+"\'','\'"+ data[i].videos[j].videoName;
//                    var url = data[i].videos[j].videoUrl;
//                    var title = data[i].videos[j].videoName;


//                    section +=
//                        '<div class="card card-body">' +
//                    '<input type="button" class="btn btn-link" onclick="playNext(\'' + url + '\' )" value="' + data[i].videos[j].videoName + '" />' +
//                    //'<input type="button" class="btn btn-link" onclick="playNext(' + url + ' )" value="' + data[i].videos[j].videoName + '" />' +
//                        '</div>'

//                }
//                section+='</div>';

//            }
//            document.getElementById('divID').innerHTML = section;
//            // Feaking an ajax response...
//            //  success(data);
//        }
//    })
//}


//function playNext(url) {
//    $("#video").attr("src", "https://youtube.com/embed/" + url);

//}