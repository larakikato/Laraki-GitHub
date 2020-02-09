<?php

    // configuration
    require("../includes/config.php");

    // if user reached page via GET (as by clicking a link or via redirect)
    if ($_SERVER["REQUEST_METHOD"] == "GET")
    {
        // render form
        render("register_form.php", ["title" => "Register"]);
    }

    // else if user reached page via POST (as by submitting a form via POST)
    else if ($_SERVER["REQUEST_METHOD"] == "POST")
    {
        if (empty($_POST["username"]))
        {
            render("register_form_tryagain.php", ["title" => "Try Again!", "Error_Message" =>"Invalid Username! BAD BOY!"]);
        }
        else if ( empty($_POST["password"]))
        {
            render("register_form_tryagain.php", ["title" => "Try Again!", "Error_Message" =>"You didn't set the password! BAD! BOY!"]);
        }
        else if ( empty($_POST["confirmation"]) || $_POST["password"] != $_POST["confirmation"])
        {
            render("register_form_tryagain.php", ["title" => "Try Again!", "Error_Message" =>"Verify your password confirmation!....... bad boy!"]);
        }
        else if ($_POST["username"] === $_POST["password"])
        {
            render("register_form_tryagain.php", ["title" => "Try Again!", "Error_Message" =>"USERNAME AND PASSWORD MUST BE DIFFERENT......... BAD!!! BOY!!!"]);
        }
        else 
        {
            $var = CS50::query("INSERT IGNORE INTO users (username, hash, cash) VALUES(?, ?, 10000.0000)", $_POST["username"], password_hash($_POST["password"], PASSWORD_DEFAULT));
            if ($var == 0)
            {
            render("register_form_tryagain.php", ["title" => "Try Again!", "Error_Message" =>"Sorry! That username already exists."]);
            }
            else
            {
                
                $rows = CS50::query("SELECT LAST_INSERT_ID() AS id");
                $id = $rows[0]["id"];
                $_SESSION["id"] = $id;
                $newUsername = $_POST["username"];
                render("register_success.php", ["title" => "Registration Successful!", "Success_Message" =>"Thanks $newUsername, you have been successfully registered!", "Refresh" => "Register Successful"]);
                //credit: https://scottiestech.info/2014/07/01/javascript-fun-looping-with-a-delay/
                //&
                //https://www.w3schools.com/howto/howto_js_countdown.asp
            }
        }
    }

?>