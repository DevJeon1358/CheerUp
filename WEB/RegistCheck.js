function validate(){
    //console.log("I am chosen one!");
    var re = /^[a-zA-Z0-9]{4,12}$/ // 아이디와 패스워드가 적합한지 검사할 정규식
    

    var id = document.getElementById("id");
    var pw = document.getElementById("password");
    var name = document.getElementById("name");
     
    
    /* if(!check(re,id,"아이디는 4~12자의 영문 대소문자와 숫자로만 입력")) {//
          return false;
     }*/
if(id.value==""){
    alert("아이디를 입력해 주세요");
    return false;
}
else if(!id.value==""){
    if(!check(re,id,"아이디는 4~12자의 영문 대소문자와 숫자로만 입력하세요")){
    return false;
  }

}


if(pw.value==""){
    alert("비밀번호를 입력하세요");
    return false;
}

else if(!pw.value==""){
    if(!check(re,pw,"패스워드는 4~12자의 영문 대소문자와 숫자로만 입력")) {
      return false;
    }

}


if(name.value=="") {
      alert("이름을 입력해 주세요");
    return false;
 }   

alert("회원가입이 완료되었습니다.");

}

function check(re, what, message) {///
if(re.test(what.value)) {
return true;
}
alert(message);
what.value = "";
what.focus();
//return false;
}