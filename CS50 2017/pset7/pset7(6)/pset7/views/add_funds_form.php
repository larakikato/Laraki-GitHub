<div>
    <iframe class="rickroll" allowfullscreen height="150" src="https://www.youtube.com/embed/oHg5SJYRHA0?autoplay=1&iv_load_policy=3&rel=0" width="225"></iframe>
</div>
<?php
    if(isset($error))
    {
        echo"<div><br><span>$error</span></div>";
        echo"<br>";
    }
?>
<div>
    <p>Deposits capped at $500.00 per day.</p>
    <form action="add_funds.php" method="post">
        <fieldset>
            <div class="form-group">
                <input autocomplete="off" autofocus class="form-control" name="deposit" placeholder="Enter deposit amount." type="text"/>
            </div>
            <div class="form-group">
                <button class="btn btn-default" type="submit">
                    <span aria-hidden="true" class="glyphicon glyphicon-ok-sign"></span>
                    Deposit!
                </button>
            </div>
        </fieldset>
    </form>
</div>
</div>