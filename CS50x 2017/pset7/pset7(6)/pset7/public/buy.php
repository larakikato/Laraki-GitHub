<?php

    // configuration
    require("../includes/config.php");
    
    // if user reached page via GET (as by clicking a link or via redirect)
    if ($_SERVER["REQUEST_METHOD"] == "GET")
    {
        // render form
        render("buy_form.php", ["title" => "Buy stocks!"]);
    }
    else if ($_SERVER["REQUEST_METHOD"] == "POST")
    {
        //var_dump($_POST); //array(2) { ["symbol"]=> string(4) "AAPL" ["shares"]=> string(4) "1000" } 
        
        //logic section
        $userID = $_SESSION["id"];
        $symbol = strtoupper($_POST["symbol"]);
        $shares = $_POST["shares"];
        $currLookup = lookup($symbol);
        if($currLookup == false)
        {
            render("buy_error_form.php", ["title" => "Buy stocks!"]);
        }
        else
        {
            $price = $currLookup["price"];
            //make sure user can only purchase whole shares of stocks
            $sharesValidator = preg_match("/^\d+$/", $_POST["shares"]);
            $currCash[] = CS50::query("SELECT cash FROM users WHERE id = $userID");
            $totalCost = ($shares * $currLookup["price"] );
            //make sure user has enough cash, execute purchase, and redirect
            if ($currCash[0][0]["cash"] >= $totalCost && $sharesValidator == 1)
            {
                CS50::query("UPDATE users SET cash = cash - $totalCost WHERE id = $userID");
                CS50::query("INSERT INTO portfolios (user_id, symbol, shares) VALUES($userID, '$symbol', $shares) ON DUPLICATE KEY UPDATE shares = shares + VALUES(shares)");
                //query to add to history table
                CS50::query("INSERT INTO history (user_id, symbol, shares, price, date, type) VALUES($userID, '$symbol', $shares, $price, CURRENT_TIMESTAMP, 'Buy')");
                
                redirect("index.php");
            }
            else //redirect user to buy_error_form
            {
                render("buy_error_form.php", ["title" => "Buy stocks!"]);
            }
        
        }
    }
?>