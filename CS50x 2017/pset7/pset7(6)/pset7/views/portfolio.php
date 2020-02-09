<div>
    <iframe allowfullscreen height="150" src="https://www.youtube.com/embed/oHg5SJYRHA0?autoplay=1&iv_load_policy=3&rel=0" width="225"></iframe>
</div>
</div>
<div class="container">
    <table class="table table-hover">
        <thead>
          <tr>
              <th>Symbol</th>
              <th>Name</th>
              <th>Shares</th>
              <th>Price</th>
              <th>Total</th>
          </tr>
        </thead>
        <tbody class="tablebody">
        <?php
        if(!empty($positions)){
            foreach ($positions as $position)
            {
                $total = number_format(($position["price"] * $position["shares"]), 2);
                print("<tr>");
                print("<td>" . $position["symbol"] . "</td>");
                print("<td>" . $position["name"] . "</td>");
                print("<td>" . $position["shares"] . "</td>");
                print("<td>" . $position["price"] . "</td>");
                print("<td>" . "$" . $total . "</td>");
                print("</tr>");
            }
        }
        ?>
        </tbody>
    </table>
        <?php
        if(empty($positions))
        {
            print("<div>");
            print("Your portfolio is currently empty.");
            print("</div>");
        }
        ?>
</div>
<div>
    <br><span><?php echo "Cash Balance = $" . $cash; ?></span>
</div>
