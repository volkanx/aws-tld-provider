# AWS TLD Provider
A project to get the list of supported TLDs by AWS Route 53 service

Currently there is no API method to get supported TLD list for AWS. This project aims to temporarily fill that gap by parsing the list from Amazon's [documentation](http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/registrar-tld-list.html)

This method is prone to error and can break easily. Also doesn't return any additional information about the TLD such as registration prices or types of the domain (generic, geographic)  

For implementation notes please check out the accompanying blog post: http://volkanpaksoy.com/archive/... 


