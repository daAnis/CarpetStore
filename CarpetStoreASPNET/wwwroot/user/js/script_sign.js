//Сценарий 6: проверка правильности заполения полей авторизации
function frmSubmit() {
    //email
    var field = document.getElementById("email");
    var p = /^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$/;
    var str = field.value;
    if (!p.test(str)) {
        field.style.backgroundColor = "#FFE4E1";
        field.select();
        return false;
    }
    field.style.backgroundColor = "#FFFFFF";
    //пароль: (Строчные и прописные латинские буквы, цифры, спецсимволы. Минимум 8 символов)
    field = document.getElementById("passwrd");
    p = /(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$/;
    str = field.value;
    if (!p.test(str)) {
        field.style.backgroundColor = "#FFE4E1";
        field.select();
        return false;
    }
    field.style.backgroundColor = "#FFFFFF";
    //Фамилия
    field = document.getElementById("last-name");
    p = /[А-Яа-яЁё]+(\s+[А-Яа-яЁё]+)?/;
    str = field.value;
    if (!p.test(str)) {
        field.style.backgroundColor = "#FFE4E1";
        field.select();
        return false;
    }
    field.style.backgroundColor = "#FFFFFF";
    //Имя
    field = document.getElementById("first-name");
    str = field.value;
    if (!p.test(str)) {
        field.style.backgroundColor = "#FFE4E1";
        field.select();
        return false;
    }
    field.style.backgroundColor = "#FFFFFF";
    //Отчество
    field = document.getElementById("middle-name");
    str = field.value;
    if (!p.test(str)) {
        field.style.backgroundColor = "#FFE4E1";
        field.select();
        return false;
    }
    field.style.backgroundColor = "#FFFFFF";
    //Телефон
    field = document.getElementById("phone");
    p = /^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/;
    str = field.value;
    if (!p.test(str)) {
        field.style.backgroundColor = "#FFE4E1";
        field.select();
        return false;
    }
    field.style.backgroundColor = "#FFFFFF";
    //Адрес
    field = document.getElementById("address");
    p = /^(\d){6}([,\sА-Яа-яЁё]+([,А-Яа-яЁё\d]+)?)$/;
    str = field.value;
    if (!p.test(str)) {
        field.style.backgroundColor = "#FFE4E1";
        field.select();
        return false;
    }
    field.style.backgroundColor = "#FFFFFF";
    return true;
}

window.onload = function () {
    document.frm.reset();
}