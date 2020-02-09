<?php

    // configuration
    require("../includes/config.php");
    
    //logic section
    $userID = $_SESSION["id"];
    $currCurrency = CS50::query("SELECT cash FROM users WHERE id = $userID");
    $cash = number_format($currCurrency[0]["cash"], 3);
    $errorMessage;
    
    // if user reached page via GET (as by clicking a link or via redirect)
    if ($_SERVER["REQUEST_METHOD"] == "GET")
    {
        // render form
        render("add_funds_form.php", ["title" => "Add Funds!"]);
    }
    else if ($_SERVER["REQUEST_METHOD"] == "POST")
    {
        $deposit = $_POST["deposit"];
        $currDate = CS50::query("SELECT CURRENT_TIMESTAMP");
        $currDate = substr($currDate[0]["CURRENT_TIMESTAMP"], 0, 10);
        $firstAddToday;
        //var_dump($_POST); array(1) { ["deposit"]=> string(3) "500" } 
        if ($_POST["deposit"] < '.01' || $_POST["deposit"] > 500)
        {
            $errorMessage = "Invalid deposit amount entered! Try again.";
            render("add_funds_form.php", ["title" => "Add Funds!", "error" => $errorMessage]);
        }
    $query = CS50::query("SELECT symbol, date, type FROM history where user_id = $userID");
    // var_dump($query); //array(5) { [0]=> array(3) { ["symbol"]=> string(4) "AAPL" ["date"]=> string(19) "2017-03-24 01:20:02" ["type"]=> string(3) "Buy" } [1]=> array(3)
        foreach($query as $array)
        {
            $array["date"] = substr($array["date"], 0, 10);
            if($array["symbol"] == 'N/A' && $array["date"] == $currDate && $array["type"] == 'Add')
            {
                $errorMessage = "Sorry, you can only add funds once per day!";
                $firstAddToday = "no";
            }
        }
        
        if(isset($firstAddToday))
        {
            render("add_funds_form.php", ["title" => "Add Funds!", "error" => $errorMessage]);
        }
        else
        {
            CS50::query("UPDATE users SET cash = cash + $deposit WHERE id = $userID");
            CS50::query("INSERT INTO history (user_id, symbol, shares, price, date, type) VALUES($userID, 'N/A', 0, $deposit, CURRENT_TIMESTAMP, 'Add')");
            
            redirect("index.php");
        }
    }
?>