<?php

    // configuration
    require("../includes/config.php"); 

    // if user reached page via GET (as by clicking a link or via redirect)
    if ($_SERVER["REQUEST_METHOD"] == "GET")
    {
        // else render form
        render("quote_form.php", ["title" => "Get a quote."]);
    }

    // else if user reached page via POST (as by submitting a form via POST)
    else if ($_SERVER["REQUEST_METHOD"] == "POST")
    {
        $stock = lookup($_POST["symbol"]);
        $symbol = $stock["symbol"];
        $name = $stock["name"];
        $price = number_format($stock["price"], 2);
        
        // validate submission
        if ($stock == false)
        {
            render("quote_form.php", ["title" => "Get a quote.", "result" => "false"]);
        }
        else
        {
            render("quote_return.php", ["title" => "Here's your quote!", "symbol" => $symbol, "name"=> $name, "price" => $price]);
        }
    
    }

?>
