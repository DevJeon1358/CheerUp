
function MainContent(roomNum) {
    var li = $('<li/>');
    var content = $('<div id="content" class="uk-position-center uk-overlay uk-overlay-default"></div>');
    var content_top = $('<div id="content_top"></div>');
    var top_div = $(`
                            <div class="top_div">
                                <img class="title" src="img/logo.png">
                                <p class="title_sub">응원메세지를 남겨주세요!!</p>
                            </div>
                    `);
    var main_div = $('<div class="main_div"></div>');
    var form = $(`<form/>`);
    var h1 = $(`<h1 class="main_div_title uk-heading-line uk-text-center"><span>응원 메세지</span></h1>`);
    var textarea = $(`<textarea class="cheerup_textarea"></textarea>`);
    var input = $('<input class="submit_btn uk-button uk-button-small uk-button-secondary uk-position-bottom-right uk-position-large" type="submit" value="제출">');

    form.append(h1);
    form.append(textarea);
    form.append(input);
    form.on("submit",function(e){
        e.preventDefault()
        socket.emit('addmessage', {
            Content: $('.cheerup_textarea').html(),
            Place: roomNum
        })
    })

    main_div.append(form);

    content.append(content_top);
    content.append(top_div);
    content.append(main_div);
    li.append(content);
    $('.uk-slideshow-items').prepend(li);
}

function AddContent(message) {
    var li = $('<li/>');
    var content = $('<div id="content" class="uk-position-center uk-overlay uk-overlay-default"></div>');
    var content_top = $('<div id="content_top"></div>');
    var top_div = $(`
                            <div class="top_div">
                                <img class="title" src="img/logo.png">
                                <p class="title_sub">다른 사람이 남긴 응원메세지</p>
                            </div>
                    `);
    var main_div = $('<div class="main_div"></div>');
    var h1 = $(`<h1 class="other_message uk-heading-line uk-text-center"><span>${message}</span></h1>`);

    main_div.append(h1);

    content.append(content_top);
    content.append(top_div);
    content.append(main_div);
    li.append(content);
    $('.uk-slideshow-items').append(li);
}

function Request() {
    var requestParam = "";

    //getParameter 펑션
    this.getParameter = function (param) {
        //현재 주소를 decoding
        var url = unescape(location.href);
        //파라미터만 자르고, 다시 &그분자를 잘라서 배열에 넣는다. 
        var paramArr = (url.substring(url.indexOf("?") + 1, url.length)).split("&");

        for (var i = 0; i < paramArr.length; i++) {
            var temp = paramArr[i].split("="); //파라미터 변수명을 담음

            if (temp[0].toUpperCase() == param.toUpperCase()) {
                // 변수명과 일치할 경우 데이터 삽입
                requestParam = paramArr[i].split("=")[1];
                break;
            }
        }
        console.log(param)
        console.log(requestParam)
        return requestParam;
    }
}