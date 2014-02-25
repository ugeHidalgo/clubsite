var images = new Array();
images[0] = '../Images/MainSlider/image0.jpg';
images[1] = '../Images/MainSlider/image1.jpg';
images[2] = '../Images/MainSlider/image2.jpg';
var index = 1; // Number of first picture to appear.
var slideInterval = 5000; //Time between change
var efectSpeed = 2000;  //Transition speed for efects.
var animationType = 'Fade'; //Trasition efect, choose between: Fade NoEfect Slide Toggle

//Main start
$(document).ready(initSlider());


function initSlider() {
    slideInterval = slideInterval + 2 * efectSpeed;
    setInterval(loadImageIntoSlider, slideInterval);
}

function loadImageIntoSlider() {

    switch (animationType) {
        case 'Fade':
            fadeSlide();
            break;
        case 'NoEfect':
            noEfectSlide()
            break;
        case 'Slide':
            slideSlide()
            break;
        case 'Toggle':
            toggleSlide()
            break;
        default:
            noEfectSlide();
            break;
    }

}


function fadeSlide() {
    var Slide = document.getElementById("SlideImage");
    $(Slide).fadeOut(efectSpeed, function () {
        //After fadeout image change the src pointing to the following image.
        Slide.src = images[index];
    });
    $(Slide).fadeIn(efectSpeed, function () {
        //After fadeIn image change the counter pointing to the following image.
        index++;
        if (index == images.length) {
            index = 0;
        }
    });
}


function slideSlide() {
    var Slide = document.getElementById("SlideImage");
    $(Slide).slideUp(efectSpeed, function () {
        //After slide up image change the src pointing to the following image.
        Slide.src = images[index];
    });
    $(Slide).slideDown(efectSpeed, function () {
        //After slide Down image change the counter pointing to the following image.
        index++;
        if (index == images.length) {
            index = 0;
        }
    });
}


function toggleSlide() {
    var Slide = document.getElementById("SlideImage");
    $(Slide).slideToggle(efectSpeed, function () {
        //After toggle image change the src pointing to the following image.
        Slide.src = images[index];
    });
    $(Slide).slideToggle(efectSpeed, function () {
        //After toggle image change the counter pointing to the following image.
        index++;
        if (index == images.length) {
            index = 0;
        }
    });
}

function noEfectSlide() {
    var Slide = document.getElementById("SlideImage");
    //After fadeout image change the src pointing to the following image.
    Slide.src = images[index];
    //After fadeIn image change the counter pointing to the following image.
    index++;
    if (index == images.length) {
        index = 0;
    }
}

