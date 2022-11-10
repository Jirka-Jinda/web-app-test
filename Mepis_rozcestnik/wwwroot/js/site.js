// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function init() {
    //add_events();
    class_changer();
    footer_upd();
}

function add_events() {
    var links = document.querySelectorAll(".link > a");
    for (var i = 0; i < links.length; i++) {
        links[i].addEventListener("click", determine_url);
    }
}

function class_changer() {
    document.addEventListener("DOMContentLoaded", function (event) {
        document.getElementById("env").addEventListener('change', function (e) {
            const element = document.getElementsByTagName("html")

            // Odebrání tříd při změně
            for (var i = 0; i < element.length; i++) {
                element[i].removeAttribute('class');
            }

            // Změna třídy
            if (e.target.value === "dev") {
                element[0].classList.add("html--dev")
            }
            if (e.target.value === "test") {
                element[0].classList.add("html--test")
            }
        })
    });
}

function footer_upd() {
    document.getElementById('copyright').appendChild(
        document.createTextNode(new Date().getFullYear())
    );
}

function handle_env_change() {
    document.getElementById('frm').submit();
}