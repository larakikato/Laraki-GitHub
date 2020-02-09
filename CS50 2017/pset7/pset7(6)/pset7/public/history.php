<?php

    // configuration
    require("../includes/config.php");
    
    $userID = $_SESSION["id"];
    $positions = CS50::query("SELECT id, symbol, shares, price, date, type FROM history WHERE user_id = $userID");
    

    //render the page
    render("history_view.php", ["title" => "History", "positions" => $positions]);

?>