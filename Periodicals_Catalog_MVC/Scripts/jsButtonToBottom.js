window.onscroll = function () { scrollFunction() };

// When the user clicks on the button, scroll to the top of the document
function bottomFunction() {
    document.documentElement.style.scrollBehavior = "smooth";
    var element = document.getElementById("bottom");
    element.scrollIntoView();
    document.documentElement.style.scrollBehavior = "auto";
}