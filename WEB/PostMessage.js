function MainContent(){
    var li = $('<li/>');
    var content = $('<div id="content" class="uk-position-center uk-overlay uk-overlay-default"></div>');
    var content_top = $('<div id="content_top"></div>');
    var top_div = $(`
                            <div class="top_div">
                                <img class="title" src="img/logo.png">
                                <p class="title_sub">응원메세지ㄴㅇ를 남겨주세요!!</p>
                            </div>
                    `);
    var main_div = $('<div class="main_div"></div>');
    var form = $(`<form/>`);
    var h1 = $(`<h1 class="main_div_title uk-heading-line uk-text-center"><span>응원 메세지</span></h1>`);
    var textarea = $(`<textarea class="cheerup_textarea">asdsad</textarea>`);
    var input = $('<input class="submit_btn uk-button uk-button-small uk-button-secondary uk-position-bottom-right uk-position-large" type="submit" value="제출">');

    form.append(h1);
    form.append(textarea);
    form.append(input);

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
                                <p class="title_sub">응원메세지를 남겨주세요!!</p>
                            </div>
                    `);
    var main_div = $('<div class="main_div"></div>');
    var form = $(`<form/>`);
    var h1 = $(`<h1 class="main_div_title uk-heading-line uk-text-center"><span>응원 메세지</span></h1>`);
    var textarea = $(`<textarea class="cheerup_textarea">${message}</textarea>`);
    var input = $('<input class="submit_btn uk-button uk-button-small uk-button-secondary uk-position-bottom-right uk-position-large" type="submit" value="제출">');

    form.append(h1);
    form.append(textarea);
    form.append(input);

    main_div.append(form);

    content.append(content_top);
    content.append(top_div);
    content.append(main_div);
    li.append(content);
    $('.uk-slideshow-items').append(li);
}