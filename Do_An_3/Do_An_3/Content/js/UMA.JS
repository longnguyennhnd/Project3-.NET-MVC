if(document.readyState == 'loading') {
    document.addEventListener('DOMContentLoaded', Home)
}
else {
    Home()
}
function Home() {
    //dùng thư viện hiệu ứng khi scroll đến 1 phần tử
    new WOW().init();
    // end dùng thư viện hiệu ứng khi scroll đến 1 phần tử



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
		},5000);
	}
    // --END VIẾT JS CHO PHẦN SLIDE 28/03/2019--

    // --VIẾT JS CHO PHẦN SCROLL 05/04/2019--
    var khoitop = document.querySelector('.khoitop');
	var menu = document.querySelector('.mnu');
    var search = document.querySelector('.formtimkiem');
    var lendau = document.querySelector('.lendau');
    lendau.addEventListener('click', function() {
        $('html,body').animate({
            scrollTop : 0
        },900)
    })
    window.addEventListener('scroll',function(){
		if (window.pageYOffset > 30) {
	
			khoitop.classList.add('dinh1');
			
		}
		else {
	
			khoitop.classList.remove('dinh1');
	
        }
        if(window.pageYOffset > 50) {
            lendau.classList.add('lthienra');
        }
        else {
            lendau.classList.remove('lthienra');
        }
		if (window.pageYOffset > 170) {
			menu.classList.add('dinh2');
			search.classList.add('dinh3');
		}
		else {
			menu.classList.remove('dinh2');
			search.classList.remove('dinh3');
		}
	})
    // --END VIẾT JS CHO PHẦN SCROLL 05/04/2019--

   

    // --VIẾT JS CHO PHẦN CLICK VÀO GIỎ HÀNG 10/04/2019--
    var giohang = document.getElementsByClassName('cart')[0];
    var nut_closse = document.getElementsByClassName('cl')[0];
    var khoigiohang = document.getElementsByClassName('giohang')[0];
    giohang.addEventListener('click', function() {
        khoigiohang.classList.remove('traive');
        khoigiohang.classList.add('phaisang');
    })
    nut_closse.addEventListener('click', function() {
        khoigiohang.classList.remove('phaisang');
        khoigiohang.classList.add('traive');
    })
    // --END VIẾT JS CHO PHẦN CLICK VÀO GIỎ HÀNG--

    
    
    //--- Xử lý phần số lượng sản phẩm
    window.onload = function() {
        var nutcong = document.getElementsByClassName('nutcong')[0];
        var nuttru = document.getElementsByClassName('nuttru')[0];
        var sl_chitietsp = document.getElementsByClassName('soluonghang')[0];
        nutcong.addEventListener('click', function() {
            sl_chitietsp.value ++;
        })
        nuttru.addEventListener('click', function() {
            sl_chitietsp.value --;
            if(sl_chitietsp.value <= 0) {
                sl_chitietsp.value = 1;
            }
        })
        sl_chitietsp.addEventListener('change', function() {
            if(sl_chitietsp.value <= 0) {
                sl_chitietsp.value = 1;
            }
        })
    }
    //--- Xử lý js phần kích ảnh ----
    var anhcts = document.querySelectorAll('.cacanhcon img');
    var anhht = document.getElementsByClassName('anhht')[0];
    for(var i = 0; i < anhcts.length; i++) {
        anhcts[i].addEventListener('click', function() {
            for(var j = 0; j < anhcts.length; j++) {
                anhcts[j].classList.remove('kickanh');
            }
            this.classList.add('kickanh');
            anhht.src = this.src;
        })
    }
    //---end Xử lý js phần kích ảnh ----
    //----END JS CHO PHẦN CHI TIẾT SẢN PHẨM -------
    //-- VIẾT JS CHO PHẦN SLIDER SỐ LƯỢNG --
    var loctheogia = document.getElementsByClassName("loctheogia");
    for(var i = 0;i < loctheogia.length; i++) {
        var sliders = loctheogia[i].getElementsByTagName("input");
        for(var j = 0; j < sliders.length; j++) {
            if(sliders[j].type = "range") {
                sliders[j].oninput = LaySoLuong;
                sliders[j].oninput();
            }
        }
    }
    //-- end VIẾT JS CHO PHẦN SLIDER SỐ LƯỢNG --
}
// ------------------------------ HẾT READY ------------------------------------
//-- VIẾT JS CHO PHẦN SLIDER SỐ LƯỢNG --
function LaySoLuong() {
    var parent = this.parentNode;
    var sliders = parent.getElementsByTagName("input");
    var slider1 = parseFloat(sliders[0].value);
    var slider2 = parseFloat(sliders[1].value);
    if(slider1 > slider2) {
        var tmp = slider2;
        slider2 = slider1;
        slider1 = tmp;
    }
    var khoangtien = parent.getElementsByClassName('khoanggia')[0];
    khoangtien.innerHTML = slider1 + 'Đ' + ' - ' + slider2 + 'Đ';
}
//-- END VIẾT JS CHO PHẦN SLIDER SỐ LƯỢNG --