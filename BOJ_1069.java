import java.io.IOException;

public class BOJ_1069{
	
	static int x,y,d,t;
	static double ans;
	
	static public void main(String catchsunpie[]) throws IOException{
		x = nex();
		y = nex();
		d = nex();
		t = nex();
		
		ans = x+y;
		
		if(d<t)
			System.out.println(ans);
		else {
			
		}
	}
	
	static int nex() throws IOException{
		int n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
