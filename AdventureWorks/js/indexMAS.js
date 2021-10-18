
//登陆注册弹出框开始

const body = document.querySelector('body');
const modal = document.querySelector('.modal');
const modalButton = document.querySelector('.modal-button');
const closeButton = document.querySelector('.index_content');
let isOpened = false;

const openModal = () => {
    modal.classList.add('is-open');
    /*body.style.overflow = 'hidden';*/
};

const closeModal = () => {
    modal.classList.remove('is-open');
    /*body.style.overflow = 'initial';*/
};

//window.addEventListener('scroll', () => {
//  if (window.scrollY > window.innerHeight / 3 && !isOpened) {
//    isOpened = true;
//    scrollDown.style.display = 'none';
//    openModal();
//  }
//});

modalButton.addEventListener('mouseover', openModal);
closeButton.addEventListener('mouseover', closeModal);

document.onkeydown = (evt) => {
    evt = evt || window.event;
    evt.keyCode === 27 ? closeModal() : false;
};

//登陆注册弹出框结束

//登陆注册界面翻转开始

let login = document.querySelector(".login");
let signup = document.querySelector(".signup");

let loginbtn = document.querySelector(".loginbtn");
let siginupbtn = document.querySelector(".signupbtn");

let user = document.querySelector(".head");

siginupbtn.addEventListener("click", () => {
    login.style.transform = "rotateY(180deg)"
    signup.style.transform = "rotateY(0deg)";

    user.innerHTML = "create account"
})

loginbtn.addEventListener("click", () => {
    login.style.transform = "rotateY(0deg)"
    signup.style.transform = "rotateY(-180deg)";

    user.innerHTML = "account login"
})

//登陆注册界面翻转结束

//搜索框滚动动画开始
$(window).scroll(function () {
    if ($(window).scrollTop() > 100) {//这里100代表要动画的元素离最顶层的距离
        $('.returntop').addClass('returntop-active')
        $('.top-search').addClass('top-search-active txtsearchactive')
        /*$('.topimg').addClass('toprightactive')*/
        $('.txtSearch').addClass('disactive')
        $('.btnSearch').addClass('disactive')
    } else {
        $('.returntop').removeClass('returntop-active')
        $('.top-search').removeClass('top-search-active txtsearchactive')
        /*$('.topimg').removeClass('toprightactive')*/
        $('.txtSearch').removeClass('disactive')
        $('.btnSearch').removeClass('disactive')
    }

    if ($(window).scrollTop() > 1000) {
        $('.returntop').addClass('returntopposition')
    } else {
        $('.returntop').removeClass('returntopposition')
    }
});
//搜索框滚动动画结束

//回到顶部按钮开始
$(function () {
    //当点击跳转链接后，回到页面顶部位置
    $("#backtop").click(function () {
        if ($('html').scrollTop()) {
            $('html').animate({ scrollTop: 0 }, 350);//动画效果
            return false;
        }
        $('body').animate({ scrollTop: 0 }, 350);
        return false;
    });
});
//回到顶部按钮结束