import java.io.IOException;

public class Main{
	
	static int n, wall[], k, inc[], left[], right[], count;
	static long amount;
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		wall = new int[n];
		right = new int[n];
		left = new int[n];
		inc = new int[n];
		
		for(int i = 0; i < n; i++)
			wall[i] = nex();
		
		count = k = nex();
		
		while(k-->0) {
			int t = nex();
			inc[t] = nex();
			wall[t] += inc[t];
		}
		
		for(int i = 1; i < n; i++)
			left[i] = max(left[i-1],wall[i-1]);
		for(int i = n-2; i >= 0; i--)
			right[i] = max(right[i+1],wall[i+1]);
		
		if(inc[0]!=0 && wall[0]-inc[0]>=right[0])
			count--;
		if(inc[n-1]!=0 && wall[n-1]-inc[n-1]>=left[n-1])
			count--;
		
		for(int i = 1; i < n-1; i++)
			if(inc[i]!=0) {
				if(wall[i]-inc[i] >= max(left[i],right[i]))
					count--;
				else if(wall[i] <= min(left[i],right[i]))
					count--;
				else if(left[i]==right[i])
					count--;
			}
		
		for(int i = 1; i < n; i++)
			amount += min(left[i],max(wall[i],right[i]));
		
		System.out.print(count+" "+amount);
	}
	
	static int min(int i, int j) {
		return i<j?i:j;
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
	
	static int nex() throws IOException{
		int n, c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
