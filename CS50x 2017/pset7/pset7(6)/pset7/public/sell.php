<?php

    // configuration
    require("../includes/config.php");
    
    //Data Gathering
    //Call Lookup to get positions
    $userID = $_SESSION["id"]; //simplify typing of $_SESSION["id"]
    $stocksOwned[] = CS50::query("SELECT * FROM portfolios WHERE user_id = $userID"); //create an array of stocks owned by user from portfolios
    $currCurrency[] = CS50::query("SELECT cash FROM users WHERE id = $userID");
    $cash = number_format($currCurrency[0][0]["cash"], 3);
    $positions;
    $lookupCount = 0;
    $symbolsSharesPrices;
    $symShareCount = 0;
    $currLookup;
    $currPrice;

    foreach( $stocksOwned as $stock )
    {
        foreach( $stock as $stock)
        {
        $temp = lookup($stock["symbol"]);
        $temp["shares"] = $stocksOwned[0][$lookupCount]["shares"];
        $positions[$lookupCount] = $temp;
        $lookupCount++;
        
        }
    }
    
    foreach($stocksOwned as $array)
    {
        foreach ($array as $subArray)
        {
            $currLookup = lookup($subArray["symbol"]);
            $currPrice = $currLookup["price"];
            $symbolsSharesPrices[$symShareCount][0]= $subArray["symbol"];
            $symbolsSharesPrices[$symShareCount][1]= $subArray["shares"];
            $symbolsSharesPrices[$symShareCount][2]= $currPrice;
            $symShareCount++;
        }
    }
    //end Data gathering

    // if user reached page via GET (as by clicking a link or via redirect)
    if ($_SERVER["REQUEST_METHOD"] == "GET")
    {
            // render form
            if(isset($symbolsSharesPrices))
            {
            render("sell_form.php", ["title" => "Sell your stocks.", "symbolsSharesPrices" => $symbolsSharesPrices, "user" => $userID]);
            }
            else
            {
                render("sell_form.php", ["title" => "Sell your stocks.", "user" => $userID]);
            }
        }
    else if ($_SERVER["REQUEST_METHOD"] == "POST")
    {
        $key = key($_POST);
        $profit = $_POST[$key];
        for ($i = 0, $j = strlen($key); $i < $j; $i++)
        {
            if ($key[$i] == '_')
            {
                $key[$i] = '.';
            }
        }
        $shares;
        $price;
        foreach($positions as $array)
        {
            if ($array["symbol"] == $key) {
                $shares = $array["shares"];
                $price = $array["price"];
            }
        }
        
        var_dump($key);
        
        CS50::query("DELETE FROM portfolios WHERE user_id = $userID AND symbol = '$key'");
        CS50::query("UPDATE users SET cash = cash + $profit WHERE id = $userID");
        //query to add to history table
        CS50::query("INSERT INTO history (user_id, symbol, shares, price, date, type) VALUES($userID, '$key', $shares, $price, CURRENT_TIMESTAMP, 'Sell')");
        
        
        redirect("index.php");
    }
?>