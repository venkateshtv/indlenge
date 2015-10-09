import csv
import MySQLdb

filePath = 'C:\My Works\Indix\code\indelenge\DatabaseScripts\Sample Data.csv'
try:
    #Start
    indixdb = MySQLdb.connect(host='localhost',user='root',passwd='admin123*',db='indix')
    cursor = indixdb.cursor()

    products = csv.reader(file(filePath))
    next(products, None)
    print 'Processing........'
    for product in products:

        query = 'insert into indixpricing(`ID`,`Title`,`Store`,`Price`,`Top Level Category`,`Sub Category`) values (%s,%s,%s,%s,%s,%s)'
        cursor.execute(query,product)

    indixdb.commit()
    cursor.close()
    print "Completed"

except Exception as e:
    print 'Oops! Something went wrong'
