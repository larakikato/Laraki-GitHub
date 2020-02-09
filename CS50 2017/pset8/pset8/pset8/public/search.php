<?php

    require(__DIR__ . "/../includes/config.php");

    // numerically indexed array of places
    $places = [];

    //search database for places matching $_GET["geo"], store in $places
    $falseCheckArr = []; //array to test query for empty objects returned
    $emptySetBool = true; //bool to validate empty objects returned or not
    $falseCheckArr[] = CS50::query("SELECT * FROM places WHERE MATCH (place_name, admin_name1, admin_code1, postal_code) AGAINST (?)", $_GET["geo"]);
    foreach($falseCheckArr as $array) //for each obect in checkarray
    {
        foreach($array as $val) //foreach index in each object
        {
            if(!empty($val)) //if the index is not empty
            {
                $emptySetBool = false; //the query did not return empty results
            }
        }
    }
    if ($emptySetBool === false) //if the query did not return empty results, run the query
    {
    $places = CS50::query("SELECT * FROM places WHERE MATCH(place_name, admin_name1, admin_code1, postal_code) AGAINST (?)", $_GET["geo"]);
    }
    
    // ^Section for fulltext index
    
    $emptySetBool = true;
    unset($falseCheckArr);
    $falseCheckArr = [];
    $falseCheckArr[] = CS50::query("SELECT * FROM places WHERE postal_code LIKE ?", $_GET["geo"] . "%");
    foreach($falseCheckArr as $array)
    {
        foreach($array as $val)
        {
            if (!empty($val))
            {
                $emptySetBool = false;
            }
        }
    }
    if ($emptySetBool === false)
    {
    $places = CS50::query("SELECT * FROM places WHERE postal_code LIKE ?", $_GET["geo"] . "%");
    }
    
    // ^ Section for autocompletion on postal codes
    
    $emptySetBool = true;
    unset($falseCheckArr);
    $falseCheckArr = [];
    $falseCheckArr[] = CS50::query("SELECT * FROM places WHERE place_name LIKE ?", $_GET["geo"] . "%");
    foreach($falseCheckArr as $array)
    {
        foreach($array as $val)
        {
            if (!empty($val))
            {
                $emptySetBool = false;
            }
        }
    }
    if ($emptySetBool === false)
    {
    $places = CS50::query("SELECT * FROM places WHERE place_name LIKE ?", $_GET["geo"] . "%");
    }
    
    // ^ section for autocompletion on place names
    
    /*there appears to be some issue with the above code not working exactly as intended, for some reason we are only able to
    retain the results from one of the above queries when we were intending to be able to return the results from all three */
    
    // output places as JSON (pretty-printed for debugging convenience)
    header("Content-type: application/json");
    print(json_encode($places, JSON_PRETTY_PRINT));

?>