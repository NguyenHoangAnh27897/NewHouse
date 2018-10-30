<?php
//     if($_POST){
//     $name = $_POST['name'];
//     $email = $_POST['email'];
//     $message = $_POST['message'];

// //send email
//     mail("it@landscapeassociation.vn", "This is an email from:" .$email, $message);
//     return success;
//     }

    $name = $_POST['name'];
    $visitor_email = $_POST['email'];
    $message = $_POST['message'];
    $text = "success";
    $email_from = 'it@newhousesolution.vn' ;

    $email_subject = "New Message";

    $email_body = "User Name: $name.\n".
                    "Email: $visitor_email.\n".
                        "User Message: $message.\n";

    $to = "architect@newhousesolution.vn";

    $headers = "From: $email_from \r \n";

    $headers .="Reply-To: $visitor_email \r\n";

    if( mail($to,$email_subject,$email_body,$headers) ){
        return $text;
    } else {
        echo "the server failed to send the message. please try again later";
    }

    header("Location: index.html");
?>