// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function init() {
    add_events();
    class_changer();
    footer_upd();
}

function add_events() {
    var links = document.querySelectorAll(".link > a");
    for (var i = 0; i < links.length; i++) {
        links[i].addEventListener("click", determine_url);
    }
}

function determine_url(event) {
    console.log("klik");
    const env = document.getElementById("env").value;
    const user = document.getElementById("users").value;
    var env_url = "";
    var user_url = "";
    var platform_url = "";
    var res = "";
    var platf = event.target.id;

    // prostředí
    if (env == "production") {
        env_url = "https://emepis.cz";
    }
    else if (env == "test") {
        env_url = "https://dev.emepis.cz";
    }

    // uživatel
    if (user == "tescosw") {
        user_url = "authConfigName=ADFS";
    }
    else if (user == "uzsvm") {
        if (platf == "integ") {
            user_url = "authConfigName=MEPIS_IP_DEV";
        }
        else {
            user_url = "authConfigName=ADFS_MEPIS";
        }
    }

    // platforma
    if (platf == "mepis") {
        platform_url = "/portal";
    }
    else if (platf == "integ") {
        platform_url = "/ip";
    }
    else if (platf == "report") {
        platform_url = "/reports";
    }

    if (env == "test" && user == "tescosw" && platf == "mepis") {
        res = "https://mepistest.mepis.loc/api/v02/as/auth/login?clientName=MW_LOC&authConfigName=ADFS";
    }
    else if (env == "test" && user == "tescosw" && platf == "integ") {
        res = "https://ip.mepis.loc/ip/api/v02/as/auth/login?clientName=MW&authConfigName=MEPIS_IP_DEV";
    }
    else {
        res = res.concat(env_url, platform_url, "/api/v02/as/auth/login?clientName=MW&", user_url);
    }

    event.target.href = res;
};

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