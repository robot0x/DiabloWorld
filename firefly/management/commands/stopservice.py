#coding:utf8
'''
Created on 2013-8-11

@author: lan (www.9miao.com)
'''
import urllib,sys

def execute(*args):
    """
    """
    if not args:
        masterport =9998
        hostname = "localhost"
    else:
        if len(args)>1:  # 多个参数 host port
            hostname = args[0]
            masterport = int(args[1])
        else:
            hostname = "localhost"
            masterport = int(args[0])
        
    url = "http://%s:%s/stop"%(hostname, masterport)  # 这样好像有点不安全的样子...直接在网页可以关闭
    try:
        response = urllib.urlopen(url)
    except:
        response = None
    if response:
        sys.stdout.write("stop service success \n")
    else:
        sys.stdout.write("stop service failed \n")
    
    