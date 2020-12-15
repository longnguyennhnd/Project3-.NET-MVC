if(document.readyState == 'loading') {
    document.addEventListener('DOMContentLoaded', Home);
}
else {
    Home();
}
function Home() {
    // --VIẾT JS CHO PHẦN SLIDE 28/03/2019--
    var nut = document.querySelectorAll(".chuyenslide ul li");
	var slides = document.querySelectorAll(".cacslide ul li");
	for (var i = 0; i < nut.length; i++) {
		nut[i].addEventListener('click',function(){
			for (var i = 0; i < nut.length; i++) {
				nut[i].classList.remove('kichhoat');
			}
			this.classList.add('kichhoat');
			var nut_kichhoat = this;
			var stt = 0;
			while (nut_kichhoat = nut_kichhoat.previousElementSibling){
                stt++;
			}
			for (var i = 0; i < slides.length; i++) {
				slides[i].classList.remove('active');
			}
			slides[stt].classList.add('active');
		})
	}
	Autoslide();
	function Autoslide() {
		var thoigian = setInterval(function(){
			var slhientai = document.querySelector(".cacslide ul li.active");
			var nuthientai = document.querySelector(".chuyenslide ul li.kichhoat");
			var stt_slhientai = 0;
			while (slhientai = slhientai.previousElementSibling){
                stt_slhientai++;
			}
			if (stt_slhientai < slides.length - 1) {
				for (var i = 0; i < slides.length; i++) {
					slides[i].classList.remove('active');
				}
				for (var i = 0; i < nut.length; i++) {
					nut[i].classList.remove('kichhoat');
				}
				slides[stt_slhientai].nextElementSibling.classList.add('active');
				nut[stt_slhientai].nextElementSibling.classList.add('kichhoat');
			}
			else {
				for (var i = 0; i < slides.length; i++) {
					slides[i].classList.remove('active');
				}
				for (var i = 0; i < nut.length; i++) {
					nut[i].classList.remove('kichhoat');
				}
				slides[0].classList.add('active');
				nut[0].classList.add('kichhoat');
			}
		},4500);
	}
    // --END VIẾT JS CHO PHẦN SLIDE 28/03/2019--

    // --VIẾT JS CHO PHẦN TÌM KIẾM SẢN PHẨM 09/04/2019--
    var nuttimkiem = document.getElementsByClassName('submit')[0];
    nuttimkiem.addEventListener('click', TimKiemSP)
    // --END VIẾT JS CHO PHẦN TÌM KIẾM SẢN PHẨM 09/04/2019--

    
    //-- VIẾT JS CHO PHẦN view --
    var nutviews = document.getElementsByClassName('xem');
    var khoixemsp = document.getElementsByClassName('khoixemsp')[0];
    var exit = document.getElementsByClassName('exit')[0];
    var kx_dganh = document.querySelector('.ndtrai img');
    var kx_ten = document.getElementsByClassName('kx_ten')[0];
    var kx_gia  = document.getElementsByClassName('kx_gia')[0];
    for(var i = 0;i < nutviews.length; i++) {
        nutviews[i].addEventListener('click', function() {
            khoixemsp.classList.toggle('hienra');
            kx_dganh.src = this.parentElement.querySelector('.anhsp').src;
            kx_ten.innerHTML = this.parentElement.querySelector('.tensp').innerHTML;
            kx_gia.innerHTML = this.parentElement.querySelector('.giasp').innerHTML;
        })
    }
    exit.addEventListener('click', function() {
        khoixemsp.classList.remove('hienra');
    })
    //-- end VIẾT JS CHO PHẦN view --
}
// --VIẾT JS CHO PHẦN TÌM KIẾM SẢN PHẨM 09/04/2019--
function TimKiemSP(event) {
    var nuttimkiem = event.target;
    var sanphams = document.getElementsByClassName('motsp');
    var otimkiem = document.getElementById('search');
    otimkiem.addEventListener('change', function() {
        if(otimkiem.value == '') {
            for(var i=0; i < sanphams.length; i++) {
                sanphams[i].classList.remove('andi');
            }
        }
    })
    var tensp_timkiem = otimkiem.value;
    tensp_timkiem = tensp_timkiem.toUpperCase();
    for(var i=0; i < sanphams.length; i++) {
        var tmp = sanphams[i].getElementsByClassName('tensp')[0].innerText;
        if(tmp.indexOf(tensp_timkiem) < 0) {
            sanphams[i].classList.add('andi');
        }
    }
}
// --END VIẾT JS CHO PHẦN TÌM KIẾM SẢN PHẨM 09/04/2019--