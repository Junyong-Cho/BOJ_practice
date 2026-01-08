import java.io.IOException;

public class BOJ_1782{
	
	static public void main(String catchsunpie[]) throws IOException{
		System.out.println(-mirror(nex()-1)+mirror(nex()));
	}
	
	static long mirror(long n) {
		if(n<0) return 0;
		if(n<1) return 1;
		if(n<8) return 2;
		if(n<10) return 3;
		
		long res = 3;
		int len = len(n);
		
		for(int i = 2; i < len; i++)
			if((i&1)==0)
				res += 4*pow(5,(i-2)>>1);
			else
				res += 4*pow(5,(i-2)>>1)*3;
		
		
		int a[] = new int[len];
		
		for(int i = len-1; i >= 0; i--) {
			a[i] = (int)(n%10);
			n /= 10;
		}
		
		for(int i = 4; i > 0; i--) {
			if(a[0]>ar[i]) {
				if((len&1)==0)
					return res + i*pow(5,len-2>>1);
				else
					return res + i*pow(5,len-2>>1)*3;
			}
			if(a[0]==ar[i]) {
				if((len&1)==0)
					res += (i-1)*pow(5,len-2>>1);
				else
					res += (i-1)*pow(5,len-2>>1)*3;
				break;
			}
		}
		
		for(int i = 1; i <(len>>1); i++) {
			for(int j = 4; j >= 0; j--) {
				if(a[i]>ar[j]) {
					if((len&1)==0)
						return res + (j+1)*pow(5,(len-2-i-i)>>1);
					else
						return res + (j+1)*pow(5,(len-2-i-i)>>1)*3;
				}
				if(a[i]==ar[j]) {
					if((len&1)==0)
						res += j*pow(5,(len-2-i-i)>>1);
					else
						res += j*pow(5,(len-2-i-i)>>1)*3;
					break;
				}
			}
		}
		
		if((len&1)==1) {
			for(int i = 2; i >= 0; i--) {
				if(a[len>>1]>arr[i])
					return res + 1+i;
				else if(a[len>>1]==arr[i]) {
					res += i;
					break;
				}
			}
		}
		
		for(int i = (len>>1)-1; i >= 0; i--) {
			if(a[i]==8) {
				if(a[len-1-i]>8)
					return res+1;
				if(a[len-1-i]<8)
					return res;
			}
			else if(a[i]==5) {
				if(a[len-1-i]>2)
					return res+1;
				if(a[len-1-i]<2)
					return res;
			}
			else if(a[i]==2) {
				if(a[len-1-i]>5)
					return res+1;
				if(a[len-1-i]<5)
					return res;
			}
			else if(a[i]==1) {
				if(a[len-1-i]>1)
					return res+1;
				if(a[len-1-i]==0)
					return res;
			}
			else {
				if(a[len-1-i]>0)
					return res+1;
			}
		}
		
		return res+1;
	}
	
	static int arr[] = {0,1,8};
	static int ar[] = {0,1,2,5,8};
	
	
	static long pow(long n, int f) {
		long res = 1;
		while(f-->0)
			res *= n;
		return res;
	}
	
	static int len(long n) {
		long ten = 1;
		int res = 0;
		while(n%ten!=n) {
			ten *= 10;
			res++;
		}
		return res;
	}
	
	static long nex() throws IOException{
		long n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
