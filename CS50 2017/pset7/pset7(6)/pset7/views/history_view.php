<div>
    <iframe allowfullscreen height="150" src="https://www.youtube.com/embed/oHg5SJYRHA0?autoplay=1&iv_load_policy=3&rel=0" width="225"></iframe>
</div>
<?php if ($positions == false): ?>
            <p><?= htmlspecialchars("Sorry, you don't have any transaction history yet!") ?></p>
<?php endif ?>
<div class="container">
    <table class="table table-hover">
        <thead>
          <tr>
              <th>Transaction ID</th>
              <th>Symbol</th>
              <th># of Shares</th>
              <th>Price Per</th>
              <th>Date</th>
              <th>Buy/Sell</th>
          </tr>
        </thead>
        <tbody class="tablebody">
<?php
    if($positions != false)
    {
        foreach($positions as $position)
        {
            echo"<tr>";
            foreach($position as $var)
            {
                echo"<td>";
                echo"$var";
                echo"</td>";
            }
            echo"</tr>";
        }
    }
?>
        </tbody>
    </table>
</div>
</div>