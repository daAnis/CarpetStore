window.onscroll = function () { myFunction(); scrollFunction() };

//Сценарий 1: "липкое" меню сверху
var navbar = document.getElementById("m-navbar");
var filters = document.getElementById("filters");
var fname = document.getElementById("fname");
var sticky = navbar.offsetTop;
var stickymenu = document.getElementById("target").offsetHeight + fname.offsetHeight;

function myFunction() {
  if (window.pageYOffset >= sticky) {
    navbar.classList.add("sticky");
  } else {
    navbar.classList.remove("sticky");
  }

  if (window.pageYOffset >= stickymenu) {
    filters.classList.add("mysticky");
  } else {
    filters.classList.remove("mysticky");
  }
}

//Сценарий 2: кнопка "Наверх"

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    document.getElementById("upBtn").style.display = "block";
  } else {
    document.getElementById("upBtn").style.display = "none";
  }
}

function topFunction() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}

//Сценарий 3: прилипший footer
function footer(){
  var
      main = document.getElementsByTagName('main')[0],
      footer = document.getElementsByTagName('footer')[0];
  
      footerHeight = footer.clientHeight;
      main.style.paddingBottom = (footerHeight)+'px';
  }
  window.addEventListener('load',footer);
  window.addEventListener('resize',footer);