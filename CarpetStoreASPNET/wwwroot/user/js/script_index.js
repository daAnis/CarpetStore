//Сценарий 4: увеличение фотографий при нажатии

/*function imgResize() {
    this.style.height = '100%'
}

function imgInitialSize() {
    this.style.height = '200px'
}

var i;
var imgs = document.getElementsByClassName("product-img");
for (i = 0; i < imgs.length; i++) {
    imgs[i].addEventListener("click", imgResize);
    imgs[i].addEventListener("mouseout", imgInitialSize);
}
*/

//Сценарий 4: раскрытие фото в большом размере
var modal = document.getElementById('myModal');
var i;
var imgs = document.getElementsByClassName("product-img");
var modalImg = document.getElementById("img01");
for (i = 0; i < imgs.length; i++) {
    var img = imgs[i];
    img.onclick = function () {
        modal.style.display = "block";
        modalImg.src = this.src;
    }
}

var span = document.getElementsByClassName("close")[0];
span.onclick = function () {
    modal.style.display = "none";
}

var slider = new Slider('#ex2', {});

//Рамка у выбранного размера
$('.size-check-label > input:checkbox').click(function(){
	if ($(this).is(':checked')) {
		$(this).parent().parent().addClass('size-check-selected');
	} else {
		$(this).parent().parent().removeClass('size-check-selected');
	}
});