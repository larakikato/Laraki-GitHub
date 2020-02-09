<div>
    <iframe allowfullscreen height="150" src="https://www.youtube.com/embed/oHg5SJYRHA0?autoplay=1&iv_load_policy=3&rel=0" width="225"></iframe>
</div>
<?php if (isset($result) && $result == "false"): ?>
    <div><?= "Sorry, That symbol does not exist!" ?></div><br>
<?php endif ?>
<form action="quote.php" method="post">
    <fieldset>
        <div class="form-group">
            <input autocomplete="off" autofocus class="form-control" name="symbol" placeholder="Enter a Symbol" type="text"/>
        </div>
        <div class="form-group">
            <button class="btn btn-default" type="submit">
                <span aria-hidden="true" class="glyphicon glyphicon-stats"></span>
                Get Quote!
            </button>
        </div>
    </fieldset>
</form>

</div>