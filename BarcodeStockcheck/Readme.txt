www.scandit.com
All about barcode recognition, not enough EAN search
(ignored)


** WINNER **    - because it's slightly cheaper than barcodelookup.com
https://go-upc.com/
Great and finds the obscure CDs
(have signed up)


https://www.ean-search.org/
Great but did not find some obscure CDs
(have not signed up)


https://account.barcodelookup.com/
Great and finds the obscure CDs
(have signed up)


-------------------------
JSON Flat File Data Store: https://ttu.github.io/json-flatfile-datastore/#/2.4.2/

- Click barcode to count one item
  - SET LOCATION CODE ONCE WHICH GETS STORED AS WE SCAN EACH ITEM
  - AND ALSO THE LOCATION DESCRIPTION (e.g. Long shed)
  - After an item is scanned:
    - Look in the local DB first, to see if it's there to save doing a barcode lookup
    - Show image to confirm
      (then let it disapear to avoid confusion since the next image will be the same... the flashing of an image is confirmation of a count)
    - Show the new count of that item, and where it is located
  - Collect a row to represent an item
    - store it with the current selected location code
    - scrape image link, Base64 image thumbnail, item description, default price, ...
    - store as json documents (ISBN or EAN number filename based? Could add first 10 characters of the title as a failsafe to avoid duplicate ISBN and EAN numbers?)
  - Button to bulk add x of these same items again    
  = Also that button resets after bulk entry, otherwise it's used to say "when I scan these add x instead of adding just the 1"

- Undo remembers last two actions

- Keep an audit of the audit
  - No of 

- Report count
  - By Publisher
  - By Location
  - By barcode
  - For all 
    - List: publisher, CD name, count, location, audit date/time