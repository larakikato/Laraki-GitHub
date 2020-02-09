<form action="register.php" method="post">
    <fieldset>
        <?php if (isset($Success_Message)): ?>
            <p><?= htmlspecialchars($Success_Message) ?></p>
            <div>
            Redirecting in <span id="counter"></span><script>(function wait (j) {setTimeout(function () {document.getElementById("counter").innerHTML = j;if (--j) {wait(j);}}, 1000);})(3); </script> seconds.
            </div>
        <?php endif ?>
    </fieldset>
</form>
<div>
    or <a href="login.php">log in</a>
</div>
</div>