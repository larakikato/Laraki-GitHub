<div>
    <iframe allowfullscreen height="150" src="https://www.youtube.com/embed/oHg5SJYRHA0?autoplay=1&iv_load_policy=3&rel=0" width="225"></iframe>
</div>
<div>
    <form action="sell.php" method="post">
        <?php
            $var = 0;
            if(isset($symbolsSharesPrices))
            {
                foreach($symbolsSharesPrices as $array) //or a foreach w/ an array of stocks
                {
                $price = $array[2];
                $shares = $array[1];
                $symbol = $array[0];
                $value = $price * $shares;
                $valueFormat = number_format($value, 2);
                if ($shares > 1){
                    $shareOrShares = "shares";
                }
                else {
                    $shareOrShares = "share";
                }
                echo "<input type=\"radio\" name=\"$symbol\" value=\"$value\" >$shares $shareOrShares of $symbol @ $$price each (Total: $$valueFormat).<br>";
                $var++;
                }
            }
            else
            {
                echo"<p>Sorry, you have nothing to sell!</p>";
            }
        ?>
        <button class="btn btn-default" type="submit">
            <span aria-hidden="true" class="glyphicon glyphicon-piggy-bank"></span>
            Sell!
        </button>
    </form>
</div>
</div>