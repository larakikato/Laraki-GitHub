<?php

    // configuration
    require("../includes/config.php"); 
    
    //Call Lookup to get positions
    $userID = $_SESSION["id"]; //simplify typing of $_SESSION["id"]
    $stocksOwned[] = CS50::query("SELECT * FROM portfolios WHERE user_id = $userID"); //create an array of stocks owned by user from portfolios
    $currCurrency[] = CS50::query("SELECT cash FROM users WHERE id = $userID");
    $cash = number_format($currCurrency[0][0]["cash"], 3);
    $positions;
    $lookupCount = 0;
    
    
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
    
    // render portfolio
    if (!empty($positions))
    {
    render("portfolio.php", ["title" => "Portfolio", "positions" => $positions, "cash" => $cash]);
    }
    else
    {
    render("portfolio.php", ["title" => "Portfiolio", "cash" => $cash]);
    }
?>
